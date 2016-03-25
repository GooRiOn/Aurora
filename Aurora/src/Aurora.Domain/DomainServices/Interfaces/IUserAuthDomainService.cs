﻿using System.Threading.Tasks;
using Aurora.Domain.DomainObjects;
using Microsoft.AspNet.Identity;

namespace Aurora.Domain.DomainServices.Interfaces
{
    public interface IUserAuthDomainService
    {
        Task<IdentityResult> CreateUserAsync(UserCreateDomainObject userCreateDomainObject);
        Task<SignInResult> PasswordSignInAsync(UserLoginDomainObject userLoginDomainObject);
        Task SignOutAsync();
        Task<string> GetUserIdAsync(string userName);
        Task<UserSelfInfoDomainObject> GetUserSelfInfoAsync(string userId);
        Task<IdentityResult> ResetUserPasswordAsync(string userId, string newPassword);
    }
}