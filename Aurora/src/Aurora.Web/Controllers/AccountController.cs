using System.Linq;
using System.Threading.Tasks;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Helpers;
using Aurora.Infrastructure.Models.ReadModels;
using Aurora.Infrastructure.Models.WriteModels;
using Aurora.Web.Auth.Interfaces;
using Aurora.Web.Services.Interfaces;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity.Design;

namespace Aurora.Web.Controllers
{
    [Route("api/Accounts")]
    public class AccountController : BaseController
    {
        private readonly IUserAuthDomainServiceProxy _userAuthDomainServiceProxy;
        private readonly IOAuthService _oAuthService;
        private readonly IEmailService _emailService;
        private readonly IHttpService _httpService;
        

        public AccountController(IUserAuthDomainServiceProxy userAuthDomainServiceProxy, IOAuthService oAuthService, IEmailService emailService, 
             IHttpService httpService)
        {
            _userAuthDomainServiceProxy = userAuthDomainServiceProxy;
            _oAuthService = oAuthService;
            _emailService = emailService;
            _httpService = httpService;
        }

        [HttpPost("Register"), AllowAnonymous]
        public async Task<IResult> RegisterUserAsync([FromBody] UserRegisterWriteModel userRegister)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage).ToArray();
                return CreateResult(ResultStateEnum.Failed, errors);
            }

            var gravatarUrl = GravatarHelper.CreateGravatarUrl(userRegister.UserName);
            userRegister.Gravatar = await _httpService.GetByteArrayAsync(gravatarUrl);

            var registerResult = await _userAuthDomainServiceProxy.CreateUserAsync(userRegister);

            if (!registerResult.Succeeded)
            {
                var errors = registerResult.Errors.Select(e => e.Description).ToArray();
                return CreateResult(ResultStateEnum.Failed, errors);
            }

            return CreateResult();
        }

        [HttpPost("Login"), AllowAnonymous]
        public async Task<string> LoginUserAsync([FromBody] UserLoginWriteModel userLogin)
        {
            var user = await _userAuthDomainServiceProxy.GetUserLoginInfoAsync(userLogin.UserName);

            if (user == null || !user.IsActive)
            {
                throw new OperationException("User not found");
            }

            if (user.IsLocked)
            {
                throw new OperationException("User is locked");
            }

            var signInResult = await _userAuthDomainServiceProxy.PasswordSignInAsync(userLogin);

            if (!signInResult.Succeeded)
            {
                throw new OperationException("Sign in failed");
            }

            var userToken = _oAuthService.GetUserAuthToken(userLogin.UserName, user.Id, user.Roles);
            
            return userToken;
        }

        [HttpGet("SelfInfo")]
        public async Task<UserSelfInfoReadModel> GetUserSelfInfo()
        {
            var userId = GetUserId();
            var result = await _userAuthDomainServiceProxy.GetUserSelfInfoAsync(userId);

            return result;
        }

        [HttpPost("SignOut"),AllowAnonymous]
        public async Task<IResult> SignOutAsync()
        {
            await _userAuthDomainServiceProxy.SignOutAsync();
            return new Result();
        }

        [HttpPost("Password/Reset/{email}/Email/Send"), AllowAnonymous]
        public async Task<IResult> SendPasswordResetEmailAsync(string email)
        {
            var passwordResetToken = await _userAuthDomainServiceProxy.GeneratePasswordResetTokenAsync(email);
            var encodedPasswordResetToken = Base64Helper.Encode(passwordResetToken);

            await _emailService.SendResetPaswordEmail(encodedPasswordResetToken, email);
            return new Result();
        }

        [HttpPost("Password/Reset"), AllowAnonymous]
        public async Task<IResult> ResetUserPasswordAsync([FromBody]UserPasswordResetWriteModel userPasswordReset)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage).ToArray();
                return CreateResult(ResultStateEnum.Failed, errors);
            }

            userPasswordReset.Token = Base64Helper.Decode(userPasswordReset.Token);

            var result = await _userAuthDomainServiceProxy.ResetUserPasswordAsync(userPasswordReset);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToArray();
                return CreateResult(ResultStateEnum.Failed, errors);
            }

            return CreateResult();
        }
    }
}
