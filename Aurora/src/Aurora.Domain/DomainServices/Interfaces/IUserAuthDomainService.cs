using System.Threading.Tasks;
using Aurora.Infrastructure.Models;
using Microsoft.AspNet.Identity;

namespace Aurora.Domain.DomainServices.Interfaces
{
    public interface IUserAuthDomainService
    {
        Task<IdentityResult> CreateUserAsync(UserCreateModel userCreateModel);
        Task<SignInResult> PasswordSignInAsync(UserLoginModel userLoginModel);
        Task SignOutAsync();
    }
}