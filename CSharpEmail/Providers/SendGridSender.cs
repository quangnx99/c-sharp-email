namespace CSharpEmail.Providers
{
    using System;
    using System.Threading.Tasks;
    using CSharpEmail.Configurations;
    using Microsoft.Extensions.Options;
    using SendGrid;
    using SendGrid.Helpers.Mail;

    public class SendGridSender : BaseSender
    {
        private readonly Lazy<SendGridClient> _sendGridClientIntance;
        private readonly SendGridOptions _sendGridOptions;

        public SendGridSender(IOptions<SendGridOptions> sendGridOptions)
        {
            _sendGridOptions = sendGridOptions.Value;

            _sendGridClientIntance = new Lazy<SendGridClient>(() =>
            {
                return new SendGridClient(_sendGridOptions.ApiKey);
            });
        }

        protected override async Task ExecuteAsync(string subject, string[] emails, string message)
        {
            var client = _sendGridClientIntance.Value;

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_sendGridOptions.SenderEmail, _sendGridOptions.SenderName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            foreach (var email in emails)
            {
                msg.AddTo(new EmailAddress(email));
            }

            await client.SendEmailAsync(msg);
        }
    }
}
