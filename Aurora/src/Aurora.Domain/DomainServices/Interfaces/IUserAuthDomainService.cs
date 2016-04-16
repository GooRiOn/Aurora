using System.Threading.Tasks;
using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;
using Aurora.Infrastructure.Models.WriteModels;
using Microsoft.AspNet.Identity;

namespace Aurora.Domain.DomainServices.Interfaces
{
    public interface IUserAuthDomainService
    {
        Task<IdentityResult> CreateUserAsync(UserEntity user, string password);
        Task PasswordSignInAsync(UserLoginWriteModel userLoginDomainObject);
        Task SignOutAsync();
        Task<string> GetUserIdAsync(string userName);
        Task<UserLoginInfoReadModel> GetUserLoginInfoAsync(string userName);
        Task<IdentityResult> ResetUserPasswordAsync(string userId, string newPassword);
        Task<IdentityResult> ResetUserPasswordAsync(UserPasswordResetWriteModel userPasswordResetDomainObject);
        Task<string> GeneratePasswordResetTokenAsync(string email);
    }
}