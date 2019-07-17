namespace CSharpEmail.Example.SmtpClient
{
    using CSharpEmail.Example.SmtpClient.Models;
    using CSharpEmail.Extensions;
    using CSharpEmail.Interfaces;
    using CSharpEmail.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                    .AddEnvironmentVariables();

            var configuration = builder.Build();

            var services = new ServiceCollection();
            services.UseCSharpSmtpClient(configuration);

            var serviceProvider = services.BuildServiceProvider();
            var emailSender = serviceProvider.GetService<IEmailSender>();

            Console.WriteLine("Process Email....");

            await emailSender.SendEmailAsync(new Message
            {
                Emails = new string[] { "quoctuan.cqt@gmail.com" },
                Subject = "Account Activated!",
                Body = HtmlParser.GenerateBody(new ActiveUserTmpl("quoctuan-cqt", "Tuan Cao", "123456789", "Ho Chi Minh City Viet Nam"))
            });

            Console.WriteLine("Email sent!");

            Console.ReadKey();
        }
    }
}
