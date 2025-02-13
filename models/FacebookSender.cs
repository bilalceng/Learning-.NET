namespace WebApplication1.models;

public class FacebookSender: IMessageSender
{
    public void SendMessage(string userName)
    {
        Console.WriteLine($"Facebook send Message to {userName}");
    }
}