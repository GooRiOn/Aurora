using System.Threading.Tasks;
using Aurora.Infrastructure.Models;
using Microsoft.AspNet.Identity;

namespace Aurora.Services.Services.Interfaces
{
    public interface IUserAuthService
    {
        Task<IdentityResult> CreateUserAsync(UserCreateModel userCreateModel);
        Task<SignInResult> PasswordSignInAsync(UserLoginModel userLoginModel);
        Task SignOutAsync();
    }
}