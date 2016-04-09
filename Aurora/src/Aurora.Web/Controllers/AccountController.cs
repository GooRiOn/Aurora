using System.Linq;
using System.Threading.Tasks;
using Aurora.DomainProxy.Dtos;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Helpers;
using Aurora.Web.Auth.Interfaces;
using Aurora.Web.Services.Interfaces;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Server.Kestrel;
using Microsoft.Data.Entity.Design;
using Microsoft.Extensions.PlatformAbstractions;

namespace Aurora.Web.Controllers
{
    [Route("api/Accounts")]
    public class AccountController : BaseController
    {
        private readonly IApplicationEnvironment _applicationEnvironment;
        private readonly IUserAuthDomainServiceProxy _userAuthDomainServiceProxy;
        private readonly IOAuthService _oAuthService;
        private readonly IEmailService _emailService;
        private readonly IHttpService _httpService;

        public string AppBasePath => _applicationEnvironment.ApplicationBasePath;


        public AccountController(IUserAuthDomainServiceProxy userAuthDomainServiceProxy, IOAuthService oAuthService, IEmailService emailService, 
            IApplicationEnvironment applicationEnvironment, IHttpService httpService)
        {
            _userAuthDomainServiceProxy = userAuthDomainServiceProxy;
            _oAuthService = oAuthService;
            _emailService = emailService;
            _applicationEnvironment = applicationEnvironment;
            _httpService = httpService;
        }

        [HttpPost("Register"), AllowAnonymous]
        public async Task<IResult> RegisterUserAsync([FromBody] UserRegisterDto userRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage).ToArray();
                return CreateResult(ResultStateEnum.Failed, errors);
            }

            var gravatarUrl = GravatarHelper.CreateGravatarUrl(userRegisterDto.UserName);
            userRegisterDto.Gravatar = await _httpService.GetByteArrayAsync(gravatarUrl);

            var registerResult = await _userAuthDomainServiceProxy.CreateUserAsync(userRegisterDto);

            if (!registerResult.Succeeded)
            {
                var errors = registerResult.Errors.Select(e => e.Description).ToArray();
                return CreateResult(ResultStateEnum.Failed, errors);
            }

            return CreateResult();
        }

        [HttpPost("Login"), AllowAnonymous]
        public async Task<string> LoginUserAsync([FromBody] UserLoginDto userLoginDto)
        {
            var user = await _userAuthDomainServiceProxy.GetUserLoginInfoAsync(userLoginDto.UserName);

            if (user == null || !user.IsActive)
            {
                throw new OperationException("User not found");
            }

            if (user.IsLocked)
            {
                throw new OperationException("User is locked");
            }

            var signInResult = await _userAuthDomainServiceProxy.PasswordSignInAsync(userLoginDto);

            if (!signInResult.Succeeded)
            {
                throw new OperationException("Sign in failed");
            }

            var userToken = _oAuthService.GetUserAuthToken(userLoginDto.UserName, user.Id);
            
            return userToken;
        }

        [HttpGet("SelfInfo")]
        public async Task<UserSelfInfoDto> GetUserSelfInfo()
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

            await _emailService.SendEmailAsync("Password reset", $"http://localhost:49849/#/user/password-reset?token={encodedPasswordResetToken}&email={email}",email);
            return new Result();
        }

        [HttpPost("Password/Reset"), AllowAnonymous]
        public async Task<IResult> ResetUserPasswordAsync([FromBody]UserPasswordResetDto userPasswordResetDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage).ToArray();
                return CreateResult(ResultStateEnum.Failed, errors);
            }

            userPasswordResetDto.Token = Base64Helper.Decode(userPasswordResetDto.Token);

            var result = await _userAuthDomainServiceProxy.ResetUserPasswordAsync(userPasswordResetDto);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToArray();
                return CreateResult(ResultStateEnum.Failed, errors);
            }

            return CreateResult();
        }
    }
}
