using System.Linq;
using System.Threading.Tasks;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.DomainProxy.Mappings;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;
using Aurora.Infrastructure.Models.WriteModels;
using Microsoft.AspNet.Identity;

namespace Aurora.DomainProxy.Proxies
{
    public class UserAuthDomainServiceProxy : IUserAuthDomainServiceProxy
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IUserAuthDomainService _userAuthDomainService; 

        public UserAuthDomainServiceProxy(IUnitOfWorkFactory unitOfWorkFactory, IUserAuthDomainService userAuthDomainService)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _userAuthDomainService = userAuthDomainService;
        }


        public async Task<IResult> CreateUserAsync(UserRegisterWriteModel userRegister)
        {
            var user = userRegister.AsEntity();
            var identityResult = await _userAuthDomainService.CreateUserAsync(user, userRegister.Password);

            return CreateResult(identityResult);
        }

        public async Task PasswordSignInAsync(UserLoginWriteModel userLogin)
        {
            await _userAuthDomainService.PasswordSignInAsync(userLogin);
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

        public async Task<IResult> ResetUserPasswordAsync(string userId, string newPassword)
        {
            var identityResult = await _userAuthDomainService.ResetUserPasswordAsync(userId,newPassword);
            return CreateResult(identityResult);
        }

        public async Task<IResult> ResetUserPasswordAsync(UserPasswordResetWriteModel userResetPasswordReset)
        {
            var identityResult = await _userAuthDomainService.ResetUserPasswordAsync(userResetPasswordReset);
            return CreateResult(identityResult);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string email)
        {
            return await _userAuthDomainService.GeneratePasswordResetTokenAsync(email);
        }

        private IResult CreateResult(IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
            {
                return new Result
                {
                    State = ResultStateEnum.Failed,
                    Errors = identityResult.Errors.Select(e => e.Description).ToList()
                };
            }
            return new Result();
        }
    }
}
