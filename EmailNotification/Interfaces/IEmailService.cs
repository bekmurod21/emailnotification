using EmailNotification.Models;

namespace EmailNotification.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailMessage emailMessage);
    }
}
