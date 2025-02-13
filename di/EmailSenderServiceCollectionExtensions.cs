using WebApplication1.endpoints;
using WebApplication1.models;

namespace WebApplication1.di;

public static class EmailSenderServiceCollectionExtensions
{
    public static IServiceCollection AddEmailSender(this IServiceCollection services)
    {
        services.AddProblemDetails();
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<NetworkClient>();
        services.AddScoped<MessageFactory>();
        services.AddScoped( provider =>
            new EmailServerSettings(
                Host: "smtp.server.com",
                Port: 25
            )
        );
        return services;
    }
}