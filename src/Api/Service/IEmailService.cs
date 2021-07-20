namespace Api.Service
{
    public interface IEmailService
    {
        bool SendEmail(string Body);
    }
}