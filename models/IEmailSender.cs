namespace WebApplication1.models;

public interface IEmailSender
{
    public void SendEmail(string username);
}