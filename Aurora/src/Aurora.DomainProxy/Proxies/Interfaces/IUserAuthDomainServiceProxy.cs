using System.Threading.Tasks;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;
using Aurora.Infrastructure.Models.WriteModels;
using Microsoft.AspNet.Identity;

namespace Aurora.DomainProxy.Proxies.Interfaces
{
    public interface IUserAuthDomainServiceProxy
    {
        Task<IResult> CreateUserAsync(UserRegisterWriteModel userRegisterDto);
        Task PasswordSignInAsync(UserLoginWriteModel userLoginDto);
        Task SignOutAsync();
        Task<string> GetUserIdAsync(string userName);
        Task<UserLoginInfoReadModel> GetUserLoginInfoAsync(string userName);
        Task<UserSelfInfoReadModel> GetUserSelfInfoAsync(string userId);
        Task<IResult> ResetUserPasswordAsync(string userId, string newPassword);
        Task<IResult> ResetUserPasswordAsync(UserPasswordResetWriteModel userPasswordResetDto);
        Task<string> GeneratePasswordResetTokenAsync(string email);
    }
}