using EmailNotification.Interfaces;
using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;


namespace EmailNotification.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration.GetSection("Email");
        }

        public async Task SendAsync(Models.EmailMessage emailMessage)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(this.configuration["EmailAddress"]));
            email.To.Add(MailboxAddress.Parse(emailMessage.To));
            email.Subject = emailMessage.Subject;
            email.Body = new TextPart(TextFormat.Text) { Text = emailMessage.Body };

            var smtp = new SmtpClient();
            await smtp.ConnectAsync(this.configuration["Host"], 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(this.configuration["EmailAddress"], this.configuration["Password"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
