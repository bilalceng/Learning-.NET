using WebApplication1.endpoints;

namespace WebApplication1.models;

public class HtmlEmailSender : IEmailSender
{
    private readonly NetworkClient _client;
    private readonly MessageFactory _factory;

    public HtmlEmailSender(MessageFactory factory, NetworkClient client)
    {
        _client = client;
        _factory = factory;
    }
    
    public void SendEmail(string username)
    {
        var email = _factory.CreateMessage();
        _client.SendEmail(username);
        Console.WriteLine($"HTML Email sent to {username}!");
    }
}