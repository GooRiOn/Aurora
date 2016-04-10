using System.Threading.Tasks;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.DomainProxy.Mappings;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;
using Aurora.Infrastructure.Models.WriteModels;
using Microsoft.AspNet.Identity;

namespace Aurora.DomainProxy.Proxies
{
    public class UserAuthDomainServiceProxy : BaseProxy, IUserAuthDomainServiceProxy
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IUserAuthDomainService _userAuthDomainService; 

        public UserAuthDomainServiceProxy(IUnitOfWorkFactory unitOfWorkFactory, IUserAuthDomainService userAuthDomainService)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _userAuthDomainService = userAuthDomainService;
        }


        public async Task<IdentityResult> CreateUserAsync(UserRegisterWriteModel userRegister)
        {
            var user = userRegister.AsEntity();
            return await _userAuthDomainService.CreateUserAsync(user, userRegister.Password); 
        }

        public async Task<SignInResult> PasswordSignInAsync(UserLoginWriteModel userLogin)
        {
            return await _userAuthDomainService.PasswordSignInAsync(userLogin);
        }

        public async Task SignOutAsync()
        {
            await _userAuthDomainService.SignOutAsync();
        }

        public async Task<string> GetUserIdAsync(string userName)
        {
            return await _userAuthDomainService.GetUserIdAsync(userName);
        }

        public async Task<UserLoginInfoReadModel> GetUserLoginInfoAsync(string userName)
        {
            return await _userAuthDomainService.GetUserLoginInfoAsync(userName);
        }

        public async Task<UserSelfInfoReadModel> GetUserSelfInfoAsync(string userId)
        {
            return await _userAuthDomainService.GetUserSelfInfoAsync(userId);
        }

        public async Task<IdentityResult> ResetUserPasswordAsync(string userId, string newPassword)
        {
            return await _userAuthDomainService.ResetUserPasswordAsync(userId,newPassword);
        }

        public async Task<IdentityResult> ResetUserPasswordAsync(UserPasswordResetWriteModel userResetPasswordReset)
        {
            return await _userAuthDomainService.ResetUserPasswordAsync(userResetPasswordReset);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string email)
        {
            return await _userAuthDomainService.GeneratePasswordResetTokenAsync(email);
        }
    }
}
