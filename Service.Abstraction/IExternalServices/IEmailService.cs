namespace Service.Abstraction.IExternalServices
{
    public interface IEmailService
    {
        Task SendConfirmationEmail(string userEmail, string otp);
        Task SendResetPassword(string userEmail, string otp);
        Task SendInvitation(string userEmail);
    }

}