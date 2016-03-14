using System.Threading.Tasks;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Mappings.ModelToEntity;
using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Models;
using Microsoft.AspNet.Identity;

namespace Aurora.Domain.DomainServices
{
    public sealed class UserAuthDomainService : IUserAuthDomainService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public UserAuthDomainService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(UserCreateModel userCreateModel)
        {
            var userEntity = userCreateModel.AsEntity();
            return await _userManager.CreateAsync(userEntity, userCreateModel.Password);
        }

        public async Task<SignInResult> PasswordSignInAsync(UserLoginModel userLoginModel)
        {
            return await _signInManager.PasswordSignInAsync(userLoginModel.UserName,userLoginModel.Password, userLoginModel.RememberMe, lockoutOnFailure: false);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
