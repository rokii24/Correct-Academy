using Domain.Entities.AuthenticationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories.ExternalRepositories
{
    public interface IAuthRepository
    {
        Task<(string, string, string)> LoginWithGoogle(string token, string provider);
        Task RegesterAsync(string name, string email, string password);
        Task<string> LogInAsync(string email, string password);
        Task RestPasswordAsync(string otp, string token, string userId, string newPassword);
        Task<string> RestPasswordAsync(string email, string otp);
        Task UpdatePasswordAsync(string userId, string oldPassword, string newPassword);
        Task UpdateUserAsync(IUser user);
        Task DeleteUserAsync(IUser user);
    }
}
