using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories.ExternalRepositories
{
    public interface IEmailRepository
    {
        Task SendConfirmation(string user, string otp);
        Task SendResetPassword(string user, string otp);
    }
}
