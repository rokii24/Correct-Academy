using Domain.IRepositories.DataRepository;
using Domain.IRepositories.ExternalRepositories;
using Service.Abstraction.IExternalServices;

namespace Service.ExternalServices
{
    public class ExternalService : IExternalService
    {
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;
        private readonly IFileService _fileService;


        public ExternalService(IExternalRepository repository, IAdminDataRepository dataRepository)
        {
            _authService=new AuthService(repository, dataRepository);
            _emailService = new EmailService(repository);
            _fileService = new FileService();
        }

        public IAuthService AuthService => _authService;
        public IEmailService EmailService => _emailService;

        public IFileService FileService => _fileService;

     
        public string GenerateOtp()
        {
            throw new NotImplementedException();
        }
    }
}
