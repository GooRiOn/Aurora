﻿using System.Threading.Tasks;
using Aurora.DataAccess.Entities;
using Aurora.Domain.DomainObjects;
using Microsoft.AspNet.Identity;

namespace Aurora.Domain.DomainServices.Interfaces
{
    public interface IUserAuthDomainService
    {
        Task<IdentityResult> CreateUserAsync(UserEntity user, string password);
        Task<SignInResult> PasswordSignInAsync(UserLoginDomainObject userLoginDomainObject);
        Task SignOutAsync();
        Task<string> GetUserIdAsync(string userName);
        Task<UserLoginInfoDomainObject> GetUserLoginInfoAsync(string userName);
        Task<UserSelfInfoDomainObject> GetUserSelfInfoAsync(string userId);
        Task<IdentityResult> ResetUserPasswordAsync(string userId, string newPassword);
        Task<IdentityResult> ResetUserPasswordAsync(UserPasswordResetDomainObject userPasswordResetDomainObject);
        Task<string> GeneratePasswordResetTokenAsync(string email);
    }
}