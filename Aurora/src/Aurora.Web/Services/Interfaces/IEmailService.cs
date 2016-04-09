using System;
using System.Threading.Tasks;

namespace Aurora.Web.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendProjectJoinEmail(string projectName, Guid memberToken, string receiverEmail);
        Task SendResetPaswordEmail(string passwordResetToken, string receiverEmail);
    }
}