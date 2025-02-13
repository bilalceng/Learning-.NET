using WebApplication1.models;

namespace WebApplication1.di;

public static class MessageSenderServiceCollectionExtensions
{
    public static IServiceCollection AddMessageSender(this IServiceCollection services)
    {
        services.AddScoped<IMessageSender, EmailSender>();
        services.AddScoped<IMessageSender, SmsSender>();
        services.AddScoped<IMessageSender, FacebookSender>();
        return services;
    }
}