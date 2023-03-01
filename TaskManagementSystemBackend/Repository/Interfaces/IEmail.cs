namespace TaskManagementSystemBackend.Repository.Interfaces
{
    public interface IEmail
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
