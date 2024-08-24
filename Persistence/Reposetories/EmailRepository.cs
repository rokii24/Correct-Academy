using Domain.Exceptions;
using Domain.IRepositories.ExternalRepositories;
using Persistence.ExternalConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;


namespace Persistence.Reposetories
{
    public class EmailRepository :IEmailRepository
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
        private void InitiateMail(string userMail, string subject, string bodyMess, string fileBodyPath)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(_configuration.SenderEmail);
                mailMessage.To.Add(new MailAddress(userMail));
                mailMessage.Subject = subject;
                if (System.IO.File.Exists(fileBodyPath))
                {
                    using (StreamReader reader = System.IO.File.OpenText(fileBodyPath))
                    {
                        mailMessage.Body = reader.ReadToEnd();
                    }

                    mailMessage.Body = mailMessage.Body
                        .Replace(_configuration.Key, bodyMess);
                    mailMessage.IsBodyHtml = true;
                }
                else
                    mailMessage.Body = bodyMess;

                using (SmtpClient client = new SmtpClient(_configuration.Server, _configuration.Port))
                {
                    client.Credentials = new NetworkCredential(_configuration.SenderEmail, _configuration.Password);
                    client.EnableSsl = true;
                    client.Send(mailMessage);
                }
            }
        }
        public Task SendConfirmation(string user, string otp)
        {
            InitiateMail(user, "Confirmation Mail", otp, _configuration.ConfirmationPath);
            return Task.CompletedTask;
        }
        public Task SendResetPassword(string user, string otp)
        {
            InitiateMail(user, "RestPassword Passwoed", otp, _configuration.RestPasswordPath);
            return Task.CompletedTask;
        }

    }
}
