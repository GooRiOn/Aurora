using System.Threading.Tasks;
using Aurora.Web.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace Aurora.Web.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string subject, string body, string receiverEmail)
        {
            var mailMessage = new MimeMessage
            {
                Subject = subject,
                Body = new TextPart("plain")
                {
                    Text = body
                }
            };

            mailMessage.From.Add(new MailboxAddress("Aurora", "mail"));
            mailMessage.To.Add(new MailboxAddress(receiverEmail, receiverEmail));

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("",587,false);
                smtpClient.Authenticate("","");
                await smtpClient.SendAsync(mailMessage);
                smtpClient.Disconnect(true);
            }
        }
    }
}
