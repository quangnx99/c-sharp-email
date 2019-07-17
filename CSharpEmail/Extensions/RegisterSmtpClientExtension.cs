namespace CSharpEmail.Extensions
{
    using CSharpEmail.Configurations;
    using CSharpEmail.Interfaces;
    using CSharpEmail.Providers;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class RegisterSmtpClientExtension
    {
        public static IServiceCollection UseCSharpSmtpClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.Configure<SmtpOptions>(configuration.GetSection("MessageSender"));

            services.AddTransient<IEmailSender, SmtpSender>();

            services.AddTransient<ISmsSender, SmtpSender>();

            return services;
        }
    }
}
