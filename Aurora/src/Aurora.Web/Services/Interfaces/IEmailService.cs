using System.Threading.Tasks;

namespace Aurora.Web.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string subject, string body, string receiverEmail);
    }
}