using System.Threading.Tasks;
using Aurora.DomainProxy.Dtos;
using Aurora.Infrastructure.Data.Interfaces;
using Microsoft.AspNet.Identity;

namespace Aurora.DomainProxy.Proxies.Interfaces
{
    public interface IUserAuthDomainServiceProxy
    {
        Task<IdentityResult> CreateUserAsync(UserCreateDto userCreateDto);
        Task<SignInResult> PasswordSignInAsync(UserLoginDto userLoginDto);
        Task SignOutAsync();
        Task<string> GetUserIdAsync(string userName);
        Task<UserSelfInfoDto> GetUserSelfInfoAsync(string userId);
        Task<IdentityResult> ResetUserPasswordAsync(string userId, string newPassword);
    }
}