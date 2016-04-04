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
        private readonly IDomainServiceFactory<IUserAuthDomainService> _userAuthDomainServiceFactory; 

        public UserAuthDomainServiceProxy(IUnitOfWorkFactory unitOfWorkFactory, IDomainServiceFactory<IUserAuthDomainService> userAuthDomainServiceFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _userAuthDomainServiceFactory = userAuthDomainServiceFactory;
        }


        public async Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userAuthDomainService = _userAuthDomainServiceFactory.Get(unitOfWork);
                var user = userRegisterDto.AsEntity();

                return await userAuthDomainService.CreateUserAsync(user, userRegisterDto.Password);
            }
        }

        public async Task<SignInResult> PasswordSignInAsync(UserLoginDto userLoginModel)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userAuthDomainService = _userAuthDomainServiceFactory.Get(unitOfWork);
                var userLoginDomainObject = userLoginModel.AsDomainObject();

                return await userAuthDomainService.PasswordSignInAsync(userLoginDomainObject);
            }
        }

        public async Task SignOutAsync()
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userAuthDomainService = _userAuthDomainServiceFactory.Get(unitOfWork);
                await userAuthDomainService.SignOutAsync();
            };
        }

        public async Task<string> GetUserIdAsync(string userName)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userAuthDomainService = _userAuthDomainServiceFactory.Get(unitOfWork);
                return await userAuthDomainService.GetUserIdAsync(userName);
            };
        }

        public async Task<UserLoginInfoDto> GetUserLoginInfoAsync(string userName)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userAuthDomainService = _userAuthDomainServiceFactory.Get(unitOfWork);
                var result = await userAuthDomainService.GetUserLoginInfoAsync(userName);
                return result.AsDto();
            };
        }

        public async Task<UserSelfInfoDto> GetUserSelfInfoAsync(string userId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userAuthDomainService = _userAuthDomainServiceFactory.Get(unitOfWork);
                var result = await userAuthDomainService.GetUserSelfInfoAsync(userId);
                return result.AsDto();
            }
        }

        public async Task<IdentityResult> ResetUserPasswordAsync(string userId, string newPassword)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userAuthDomainService = _userAuthDomainServiceFactory.Get(unitOfWork);
                return await userAuthDomainService.ResetUserPasswordAsync(userId,newPassword);
            };
        }

        public async Task<IdentityResult> ResetUserPasswordAsync(UserPasswordResetDto userResetPasswordResetDto)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userAuthDomainService = _userAuthDomainServiceFactory.Get(unitOfWork);
                var userPasswordResetDomainObject = userResetPasswordResetDto.AsDomainObject();
                return await userAuthDomainService.ResetUserPasswordAsync(userPasswordResetDomainObject);
            };
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string email)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userAuthDomainService = _userAuthDomainServiceFactory.Get(unitOfWork);
                return await userAuthDomainService.GeneratePasswordResetTokenAsync(email);
            };
        }
    }
}
