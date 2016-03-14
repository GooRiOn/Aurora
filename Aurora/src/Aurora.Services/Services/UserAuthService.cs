using System.Threading.Tasks;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Infrastructure.Models;
using Aurora.Services.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace Aurora.Services.Services
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IUserAuthDomainService _userAuthDomainService;

        public UserAuthService(IUserAuthDomainService userAuthDomainService)
        {
            _userAuthDomainService = userAuthDomainService;
        }

        public async Task<IdentityResult> CreateUserAsync(UserCreateModel userCreateModel)
        {
            return await _userAuthDomainService.CreateUserAsync(userCreateModel);
        }

        public async Task<SignInResult> PasswordSignInAsync(UserLoginModel userLoginModel)
        {
            return await _userAuthDomainService.PasswordSignInAsync(userLoginModel);
        }

        public async Task SignOutAsync()
        {
            await _userAuthDomainService.SignOutAsync();
        }
    }
}
