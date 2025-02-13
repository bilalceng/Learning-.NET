namespace WebApplication1.models;

public class SmsSender : IMessageSender
{
    public void SendMessage(string userName)
    {
        Console.WriteLine($"SMS send Message to {userName}");;
    }
}