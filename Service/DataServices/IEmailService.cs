using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataServices
{
    public interface IEmailService
    {
        Task SendConfirmationEmail(string userEmail, string otp);
        Task SendResetPassword(string userEmail, string otp);
        Task SendInvitation(string userEmail);
    }
}
