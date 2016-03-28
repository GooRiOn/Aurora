using System.Linq;
using System.Threading.Tasks;
using Aurora.DomainProxy.Dtos;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Web.Auth.Interfaces;
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

        public AccountController(IUserAuthDomainServiceProxy userAuthDomainServiceProxy, IOAuthService oAuthService)
        {
            _userAuthDomainServiceProxy = userAuthDomainServiceProxy;
            _oAuthService = oAuthService;
        }

        [HttpPost("Register"), AllowAnonymous]
        public async Task<IResult> RegisterUserAsync([FromBody] UserRegisterDto userRegisterDto)
        {
            if(!ModelState.IsValid)
                return new Result
                {
                    State = ResultStateEnum.Failed,
                    Errors = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage).ToArray()
                };

            var registerResult = await _userAuthDomainServiceProxy.CreateUserAsync(userRegisterDto);

            if (!registerResult.Succeeded)
            {
                return new Result
                {
                    State = ResultStateEnum.Failed,
                    Errors = registerResult.Errors.Select(e => e.Description).ToArray()
                };
            }
            return new Result();
        }

        [HttpPost("Login"), AllowAnonymous]
        public async Task<string> LoginUserAsync([FromBody] UserLoginDto userLoginDto)
        {
            var signInResult = await _userAuthDomainServiceProxy.PasswordSignInAsync(userLoginDto);

            if (!signInResult.Succeeded)
            {
                throw new OperationException("Sign in failed");
            }
           
            var userId = await _userAuthDomainServiceProxy.GetUserIdAsync(userLoginDto.UserName);
            var userToken = _oAuthService.GetUserAuthToken(userLoginDto.UserName, userId);

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
    }
}
