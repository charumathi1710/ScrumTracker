using ScrumTracker.BAL.ICustomLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTracker.BAL.CustomLayer
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task<bool> SendEmailAsync(string subject, string body, List<string> recipients)
        {
            //var fromAddress = new MailAddress("mkcharumathi@gmail.com", "Charu");
            var fromAddress = new MailAddress("nihalanazneen027@gmail.com", "Nihala");
            var mailMessage = new MailMessage
            {
                From = fromAddress,
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            foreach (var recipient in recipients)
            {
                mailMessage.To.Add(recipient);
            }

            try
            {
                await _smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
