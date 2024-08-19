using Domain.IRepositories.ExternalRepositories;
using Service.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Service.ExternalServices.EmailService;

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

            public async Task SendInvitation(string userEmail)
            {
                await _repository.EmailRepository.SendInvitation(userEmail);
            }

            public Task SendResetPassword(string userEmail, string otp)
            {
                return _repository.EmailRepository.SendResetPassword(userEmail, otp);
            }
        }
    }

