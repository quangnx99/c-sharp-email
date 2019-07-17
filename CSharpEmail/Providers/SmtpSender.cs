namespace CSharpEmail.Providers
{
    using CSharpEmail.Configurations;
    using Microsoft.Extensions.Options;
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    public class SmtpSender : BaseSender
    {
        private readonly SmtpOptions _smtpOptions;
        private readonly Lazy<EmailSmtp> _smtpClientInstance;

        public SmtpSender(IOptions<SmtpOptions> options)
        {
            _smtpOptions = options.Value;
            _smtpClientInstance = new Lazy<EmailSmtp>(() =>
            {
                return new EmailSmtp(options.Value);
            });
        }

        protected override async Task ExecuteAsync(string subject, string[] emails, string message)
        {
            var client = _smtpClientInstance.Value;

            var mailMessage = new MailMessage();

            foreach (var email in emails)
            {
                mailMessage.To.Add(email);
            }

            mailMessage.From = new MailAddress(_smtpOptions.SenderEmail, _smtpOptions.SenderName);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;

            await client.SendMailAsync(mailMessage);
        }
    }

    public class EmailSmtp : SmtpClient
    {
        public EmailSmtp(SmtpOptions smtpOptions)
        {
            Credentials = new NetworkCredential
            {
                UserName = smtpOptions.UserName,
                Password = smtpOptions.Password
            };
            Host = smtpOptions.Host;
            Port = smtpOptions.Port;
            EnableSsl = smtpOptions.EnableSSL;
        }
    }
}
