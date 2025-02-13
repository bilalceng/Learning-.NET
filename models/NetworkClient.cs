namespace WebApplication1.endpoints;

public class NetworkClient
{
    private readonly EmailServerSettings _settings;
    public NetworkClient(EmailServerSettings settings)
    {
        _settings = settings;
    }

    public void SendEmail(string to)
    {
        
    }
}