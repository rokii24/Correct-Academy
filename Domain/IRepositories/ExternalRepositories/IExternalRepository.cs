

namespace Domain.IRepositories.ExternalRepositories
{
    public interface IExternalRepository
    {
        IEmailRepository EmailRepository { get; }
        IAuthRepository AuthRepository { get; }
        string GenerateOtp();

    }
}
