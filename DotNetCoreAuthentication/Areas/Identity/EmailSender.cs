using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using SendGrid;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

namespace DotNetCoreAuthentication.Areas.Identity
{
    public class EmailSender : IEmailSender
    {
        private readonly string _apiKey;
        private readonly string _fromName;
        private readonly string _fromEmail;
        public EmailSender()
        {
            _apiKey = "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";
            _fromName = "Renato";
            _fromEmail = "renato.alushi@etg.al";
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(_apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_fromEmail, _fromName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            msg.SetClickTracking(false, false);
            await client.SendEmailAsync(msg);
        }
    }
}
