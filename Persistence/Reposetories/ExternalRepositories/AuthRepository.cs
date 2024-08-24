using Domain.Entities.AuthenticationEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Persistence.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Role = Domain.Enums.CorrectRole;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Domain.Exceptions;
using Google.Apis.Auth;
using Persistence.ExternalConfigurations;
using Microsoft.EntityFrameworkCore;
using Domain.IRepositories.ExternalRepositories;

namespace Persistence.Reposetories.ExternalRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly GoogleConfiguration _googleConfiguration;
        private readonly UserManager<CorrectUser> _userManager;
        private readonly SignInManager<CorrectUser> _signInManager;

        private readonly JWTConfiguration _jwt;
        public AuthRepository(SignInManager<CorrectUser> signInManager,GoogleConfiguration googleConfiguration, UserManager<CorrectUser> userManager, JWTConfiguration jwt)
        {
            _googleConfiguration = googleConfiguration;
            _userManager = userManager;
            _signInManager = signInManager;

            _jwt = jwt;
        }
        private async Task SaveOTP(string userId, string otp, int mints = 3)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                if (user.OTP is not null && user.OTPValidTo > DateTime.Now)
                    throw new IdentityException("Something Heppened when Saving OTP");
                user.OTP = otp;
                user.OTPValidTo = DateTime.Now.AddMinutes(mints);
                await _userManager.UpdateAsync(user);
            }
        }
        private string FillError(IdentityResult result)
        {
            var errors = "";
            foreach (var error in result.Errors)
            {
                errors += $"{error.Description} , ";
            }
            return errors;
        }
        private CorrectUser ToCorrectUser(IUser user)
        {
            var corrcet = user as CorrectUser;
            if (corrcet is null)
                throw new NotFoundException();

            return corrcet;
        }

        private async Task ValidateOTP(CorrectUser user, string otp)
        {
            if (user.OTP == otp && user.OTPValidTo is not null && user.OTPValidTo >= DateTime.Now)
            {
                user.OTP = null;
                user.OTPValidTo = null;
                await _userManager.UpdateAsync(user);
            }
            else throw new UnauthorizedAccessException("OTP Not Valid");

        }

        private async Task<string> CreateJwtToken(CorrectUser user)
        {

            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = user.Role.Name;
            if (roles is null) roles = "";

            var roleClaims = new List<Claim>();
            roleClaims.Add(new Claim("roles", roles ?? ""));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer, audience: _jwt.Audience,
                claims: claims, expires: DateTime.Now.AddDays(_jwt.AvailavleDays),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private async Task<GoogleJsonWebSignature.Payload> GetPayload(string token)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string>() { _googleConfiguration.ClientId }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(token, settings);
            return payload;
        }

        public async Task<(string, string, string)> LoginWithGoogle(string token, string provider)
        {
            var payloadUser = await GetPayload(token);
            if (payloadUser == null) 
                throw new Exception("Notfound");
            var info = new UserLoginInfo(provider!, payloadUser.Subject, provider);

            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payloadUser.Email);

                if (user == null)
                {
                    user = new() { Email = payloadUser.Email, UserName = payloadUser.Email, Name = payloadUser.Name };
                    var results = await _userManager.CreateAsync(user);
                    if (!results.Succeeded)
                        throw new Exception("Cannot Add user");
                }
                await _userManager.AddLoginAsync(user, info);
            }
            if (user == null)
                throw new Exception("Google");
            else user = _userManager.Users
                .Include(or => or.Role).First(u => u.Email == user.Email);
            return (user.Id, await CreateJwtToken(user), user.Name);
        }
        public async Task RegesterAsync(string name, string email, string password)
        {
            if (await _userManager.FindByEmailAsync(email) is not null)
                throw new AlreadyExistException(name);

            var correctUser = new CorrectUser()
            {
                Email = email,
                Name = name,
                UserName = email
            };

            var result = await _userManager.CreateAsync(correctUser, password);
            if (!result.Succeeded)
                throw new IdentityException(FillError(result));
        }


        public async Task<string> LogInAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            user = _userManager.Users
                .Include(u => u.OrganizationRules)
                .FirstOrDefault(user => user.Email == email);
            if (user is null || !await _userManager.CheckPasswordAsync(user, password))
                throw new NotFoundException(email);

            var res = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (res.IsNotAllowed)
                throw new NotAllowedException("User");
            if (res.Succeeded)
            {
                var jwtSecurityToken = await CreateJwtToken(user);

                return jwtSecurityToken;
            }
            throw new IdentityException("Exception with Login");
        }

        public async Task RestPasswordAsync(string otp, string token, string UserId, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
                throw new NotFoundException("User");
            await ValidateOTP(user, otp);
            //if (user.OTP == otp)
            //{
            //    user.OTP = null;
            //    await _userManager.UpdateAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            if (!result.Succeeded) throw new IdentityException(FillError(result));
        }
        public async Task<string> RestPasswordAsync(string email, string otp)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new NotFoundException("User");

            //user.OTP = otp;
            //await _userManager.UpdateAsync(user);
            await SaveOTP(user.Id, otp);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return token;
        }


        public async Task UpdatePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                throw new NotFoundException("User");

            if (!await _userManager.CheckPasswordAsync(user, oldPassword))
                throw new UnauthorizedAccessException("Old password is incorrect.");

            // Change the password to the new one
            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (!result.Succeeded)
                throw new IdentityException(FillError(result));
        }

        public async Task UpdateUserAsync(IUser user)
        {
            var existingUser = await _userManager.FindByIdAsync(user.Id);
            if (existingUser == null)
                throw new NotFoundException(user.Name);

            existingUser = ToCorrectUser(user);

            var result = await _userManager.UpdateAsync(existingUser);
            if (!result.Succeeded)
                throw new IdentityException(FillError(result));
        }
        public async Task DeleteUserAsync(IUser user)
        {
            var userEntity = await _userManager.FindByIdAsync(user.Id);
            if (userEntity == null)
                throw new NotFoundException(user.Name);

            var result = await _userManager.DeleteAsync(userEntity);
            if (!result.Succeeded)
                throw new IdentityException(FillError(result));
        }
    }
}
