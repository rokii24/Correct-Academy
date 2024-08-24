using Domain.Entities.AuthenticationEntities;
using Domain.IRepositories.ExternalRepositories;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Context;
using Persistence.ExternalConfigurations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Reposetories.ExternalRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly GoogleConfiguration _googleConfiguration;
        private readonly UserManager<CorrectUser> _userManager;
        private readonly JWTConfiguration _jwt;
        public AuthRepository(GoogleConfiguration googleConfiguration, UserManager<CorrectUser> userManager, JWTConfiguration jwt)
        {
            _googleConfiguration = googleConfiguration;
            _userManager = userManager;
            _jwt = jwt;
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

        public Task RegesterAsync(string name, string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<string> LogInAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task RestPasswordAsync(string otp, string token, string userId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<string> RestPasswordAsync(string email, string otp)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(IUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(IUser user)
        {
            throw new NotImplementedException();
        }
    }
}
