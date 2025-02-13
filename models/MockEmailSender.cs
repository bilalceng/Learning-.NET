using WebApplication1.endpoints;

namespace WebApplication1.models;

public class MockEmailSender : IEmailSender
{
    private readonly NetworkClient _client;
    private readonly MessageFactory _factory;

    public MockEmailSender(MessageFactory factory, NetworkClient client)
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
}