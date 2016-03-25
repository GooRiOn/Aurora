using System;
using System.Linq;
using System.Threading.Tasks;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.DataAccess.Entities;
using Aurora.Domain.DomainObjects;
using Aurora.Domain.Mappings;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Aurora.Domain.DomainServices
{
    public sealed class UserAuthDomainService : IUserAuthDomainService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager; 
        private readonly SignInManager<UserEntity> _signInManager;

        public UserAuthDomainService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateUserAsync(UserCreateDomainObject userCreateDomainObject)
        {
            var userEntity = userCreateDomainObject.AsEntity();
            return await _userManager.CreateAsync(userEntity, userCreateDomainObject.Password);
        }

        public async Task<SignInResult> PasswordSignInAsync(UserLoginDomainObject userLoginModel)
        {
            await SignOutAsync();
            return await _signInManager.PasswordSignInAsync(userLoginModel.UserName, userLoginModel.Password, userLoginModel.RememberMe,false);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<string> GetUserIdAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user.Id;
        }

        public async Task<UserSelfInfoDomainObject> GetUserSelfInfoAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _roleManager.Roles.Where(r => r.Users.Any(u => u.UserId == userId)).Select(r => r.Name).ToArrayAsync();

            return new UserSelfInfoDomainObject {UserName = user.UserName, Roles = userRoles};
        }

        public async Task<IdentityResult> ResetUserPasswordAsync(string userId, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }
    }
}
