namespace CSharpEmail.Extensions
{
    using CSharpEmail.Configurations;
    using CSharpEmail.Interfaces;
    using CSharpEmail.Providers;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class RegisterSendGridExtension
    {
        public static IServiceCollection UseCSharpSendGrid(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.Configure<SendGridOptions>(configuration.GetSection("MessageSender"));

            services.AddTransient<IEmailSender, SendGridSender>();

            services.AddTransient<ISmsSender, SendGridSender>();

            return services;
        }
    }
}
