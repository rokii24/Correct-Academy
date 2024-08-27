
namespace Service.Abstraction.IExternalServices
{
    public interface IExternalService
    {
        IAuthService AuthService { get; }
        IEmailService EmailService { get; }
        IFileService FileService { get; }

        string GenerateOtp();
    }
}
