using System;
using System.Threading.Tasks;

namespace Aurora.Web.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendProjectJoinEmailAsync(string projectName, Guid memberToken, string receiverEmail);
        Task SendResetPaswordEmailAsync(string passwordResetToken, string receiverEmail);
    }
}