using System.Threading.Tasks;
using Aurora.DomainProxy.Dtos;
using Microsoft.AspNet.Identity;

namespace Aurora.DomainProxy.Proxies.Interfaces
{
    public interface IUserAuthDomainServiceProxy
    {
        Task<IdentityResult> CreateUserAsync(UserCreateDto userCreateDto);
        Task<SignInResult> PasswordSignInAsync(UserLoginDto userLoginDto);
        Task SignOutAsync();
    }
}