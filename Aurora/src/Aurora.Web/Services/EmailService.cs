using System;
using System.Threading.Tasks;
using Aurora.Web.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace Aurora.Web.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendProjectJoinEmail(string projectName, Guid memberToken, string receiverEmail)
        {
            var subject = $"Aurora | You've been invited to {projectName} project!";
            var body = $"http://localhost:49849/#/project/join?memberToken={memberToken}";

            await SendEmailAsync(subject, body, receiverEmail);
        }

        public async Task SendResetPaswordEmail(string passwordResetToken, string receiverEmail)
        {
            var subject = "Aurora | Reset password";
            var body = $"http://localhost:49849/#/user/password-reset?token={passwordResetToken}&email={receiverEmail}";

            await SendEmailAsync(subject, body, receiverEmail);
        }

        private async Task SendEmailAsync(string subject, string body, string receiverEmail)
        {
            var mailMessage = new MimeMessage
            {
                Subject = subject,
                Body = new TextPart("plain")
                {
                    Text = body
                }
            };

            mailMessage.From.Add(new MailboxAddress("Aurora", "aurora.info.net@gmail.com"));
            mailMessage.To.Add(new MailboxAddress(receiverEmail, receiverEmail));

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587,false);
                smtpClient.Authenticate("aurora.info.net@gmail.com", "aurora1234");
                await smtpClient.SendAsync(mailMessage);
                smtpClient.Disconnect(true);
            }
        }
    }
}
