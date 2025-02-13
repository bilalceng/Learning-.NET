using WebApplication1.endpoints;

namespace WebApplication1.models;

public class EmailSender : IEmailSender , IMessageSender
{
    private readonly NetworkClient _client;
    private readonly MessageFactory _factory;

    public EmailSender(MessageFactory factory, NetworkClient client)
    {
        _client = client;
        _factory = factory;
    }
    
    public void SendEmail(string username)
    {
        var email = _factory.CreateMessage();
        _client.SendEmail(username);
        Console.WriteLine($"Email sent to {username}!");
    }

    public void SendMessage(string userName)
    {
        Console.WriteLine($"Email send Message to {userName}");;
    }
}