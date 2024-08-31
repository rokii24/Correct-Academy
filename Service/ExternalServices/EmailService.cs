using Domain.IRepositories.ExternalRepositories;
using Service.Abstraction.IExternalServices;
namespace Service.ExternalServices
{
    public class EmailService: IEmailService
    { 


            private readonly IExternalRepository _repository;

            public EmailService(IExternalRepository repository)
            {
                _repository = repository;
            }

            public Task SendConfirmationEmail(string userEmail, string otp)
            {
                return _repository.EmailRepository.SendConfirmation(userEmail, otp);

            }

            public Task SendResetPassword(string userEmail, string otp)
            {
                return _repository.EmailRepository.SendResetPassword(userEmail, otp);
            }
        }
    }

