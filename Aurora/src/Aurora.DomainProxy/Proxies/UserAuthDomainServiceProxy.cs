using System.Threading.Tasks;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Interfaces;
using Aurora.DomainProxy.Dtos;
using Aurora.DomainProxy.Mappings;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Interfaces;
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


        public async Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto)
        {
            var user = userRegisterDto.AsEntity();
            return await _userAuthDomainService.CreateUserAsync(user, userRegisterDto.Password); 
        }

        public async Task<SignInResult> PasswordSignInAsync(UserLoginDto userLoginModel)
        {
            var userLoginDomainObject = userLoginModel.AsDomainObject();
            return await _userAuthDomainService.PasswordSignInAsync(userLoginDomainObject);
        }

        public async Task SignOutAsync()
        {
            await _userAuthDomainService.SignOutAsync();
        }

        public async Task<string> GetUserIdAsync(string userName)
        {
            return await _userAuthDomainService.GetUserIdAsync(userName);
        }

        public async Task<UserLoginInfoDto> GetUserLoginInfoAsync(string userName)
        {
            var result = await _userAuthDomainService.GetUserLoginInfoAsync(userName);
            return result.AsDto();
        }

        public async Task<UserSelfInfoDto> GetUserSelfInfoAsync(string userId)
        {
            var result = await _userAuthDomainService.GetUserSelfInfoAsync(userId);
            return result.AsDto();
        }

        public async Task<IdentityResult> ResetUserPasswordAsync(string userId, string newPassword)
        {
            return await _userAuthDomainService.ResetUserPasswordAsync(userId,newPassword);
        }

        public async Task<IdentityResult> ResetUserPasswordAsync(UserPasswordResetDto userResetPasswordResetDto)
        {
            var userPasswordResetDomainObject = userResetPasswordResetDto.AsDomainObject();
            return await _userAuthDomainService.ResetUserPasswordAsync(userPasswordResetDomainObject);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string email)
        {
            return await _userAuthDomainService.GeneratePasswordResetTokenAsync(email);
        }
    }
}
