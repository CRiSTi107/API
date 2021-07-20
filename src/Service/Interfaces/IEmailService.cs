namespace Service.Interfaces
{
    public interface IEmailService
    {
        bool SendEmail(string Body);
    }
}