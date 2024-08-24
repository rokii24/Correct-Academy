
namespace Service.Abstraction.IExternalServices
{
    public interface IExternalService
    {
        IAuthService AuthService { get; }
        IEmailService EmailService { get; }

        string GenerateOtp();
    }
}
