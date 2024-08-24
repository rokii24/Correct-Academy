using Domain.IRepositories.ExternalRepositories;
using Microsoft.Extensions.Configuration;
using Persistence.ExternalConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Reposetories.ExternalRepositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly EmailConfiguration _configuration;

        public EmailRepository(EmailConfiguration configuration)
        {
            _configuration = configuration;

            CheckMailParamters();
        }
        private void CheckMailParamters()
        {
            if (_configuration.Server is null || _configuration.SenderEmail is null
                || _configuration.Key is null || _configuration.Password is null
                || _configuration.Port == -1 || _configuration.RestPasswordPath is null
                || _configuration.InvitationPath is null || _configuration.ConfirmationPath is null)
                throw new SettingsNotFoundException("Mail Paramters Not Found");
        }
    }
}
