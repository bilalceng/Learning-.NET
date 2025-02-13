using Microsoft.AspNetCore.Mvc;
using WebApplication1.models;

namespace WebApplication1.endpoints;

public static class DISampleEndpoints
{
    public static void MapDISampleEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/register/{userName}",RegisterUser);
    }


    static string RegisterUser(string userName, [FromServices] IEnumerable<IMessageSender> messageSenders)
    {
        foreach (var sender in messageSenders)
        {
            sender.SendMessage(userName);
        }

        return $"Welcome message sent to {userName}";
    }
    // Without Dependency Injection, Creating dependencies manually.

    /*static string RegisterUser(string userName)
    {
        var emailSender = new EmailSender(
            new MessageFactory(),
            new NetworkClient(
                new EmailServerSettings(
                    Host:"yes@gmail.com",
                    Port: 993
                    )
                )
            );
        emailSender.SendEmail(userName);
        
        return $"Email sent to {userName}";

    }*/
}