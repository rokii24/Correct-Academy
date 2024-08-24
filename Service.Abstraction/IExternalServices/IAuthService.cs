using Contract.AuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.IExternalServices
{
    public interface IAuthService
    {
        Task<(string, string, string)> AuthenticationWithGoogle(GoogleAuthDto googleAuth);
        Task RegesterAsync(RegestreationDto model);
        Task<AuthDto> LogInAsync(LoginDto model);
        Task<OtpTokenDto> RestPassword(string email);
        Task RestPassword(ForgetPasswordDto forget);
        Task UpdatePasswordAsync(ChangePasswordDto changePassword);
        Task DeleteUserAsync(string userId);
    }
}
