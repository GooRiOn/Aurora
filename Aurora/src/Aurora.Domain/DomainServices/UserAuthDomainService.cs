using System;
using System.Linq;
using System.Threading.Tasks;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Data;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;
using Aurora.Infrastructure.Models.WriteModels;
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

        public async Task<IdentityResult> CreateUserAsync(UserEntity user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task PasswordSignInAsync(UserLoginWriteModel userLogin)
        {
            await _signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, userLogin.RememberMe,false);
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

        public async Task<UserLoginInfoReadModel> GetUserLoginInfoAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
                return null;

            return new UserLoginInfoReadModel
            {
                Id = user.Id,
                IsActive = user.IsActive,
                IsLocked = user.IsLocked,
                Roles = await _roleManager.Roles.Where(r => r.Users.Any(u => u.UserId == user.Id)).Select(r => r.Name).ToArrayAsync()
            };
        }

        public async Task<UserSelfInfoReadModel> GetUserSelfInfoAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _roleManager.Roles.Where(r => r.Users.Any(u => u.UserId == userId)).Select(r => r.Name).ToArrayAsync();

            return new UserSelfInfoReadModel { UserName = user.UserName, Roles = userRoles};
        }

        public async Task<IdentityResult> ResetUserPasswordAsync(string userId, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }

        public async Task<IdentityResult> ResetUserPasswordAsync(UserPasswordResetWriteModel userPasswordReset)
        {
            var user = await _userManager.FindByEmailAsync(userPasswordReset.Email);
            return await _userManager.ResetPasswordAsync(user, userPasswordReset.Token, userPasswordReset.Password);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }
    }
}
