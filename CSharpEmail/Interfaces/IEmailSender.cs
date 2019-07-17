namespace CSharpEmail.Interfaces
{
    using CSharpEmail.Models;
    using System.Threading.Tasks;

    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
    }
}
