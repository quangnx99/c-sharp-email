namespace CSharpEmail.Providers
{
    using CSharpEmail.Interfaces;
    using CSharpEmail.Models;
    using System;
    using System.Threading.Tasks;

    public abstract class BaseSender : IEmailSender, ISmsSender
    {
        public virtual async Task SendEmailAsync(Message message)
        {
            await ExecuteAsync(message.Subject, message.Emails, message.Body);
        }

        public virtual Task SendSmsAsync(string number, string message)
        {
            throw new NotImplementedException();
        }

        protected abstract Task ExecuteAsync(string subject, string[] emails, string message);
    }
}
