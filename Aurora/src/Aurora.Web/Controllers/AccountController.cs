using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Aurora.DataAccess;
using Aurora.DomainProxy.Dtos;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Web.Auth.Interfaces;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Aurora.Web.Controllers
{
    [Route("api/Accounts"),Authorize("Bearer")]
    public class AccountController : Controller
    {
        private readonly IUserAuthDomainServiceProxy _userAuthDomainServiceProxy;
        private readonly IOAuthService _oAuthService;

        public AccountController(IUserAuthDomainServiceProxy userAuthDomainServiceProxy, IOAuthService oAuthService)
        {
            _userAuthDomainServiceProxy = userAuthDomainServiceProxy;
            _oAuthService = oAuthService;
        }

        [HttpPost("Register"), AllowAnonymous]
        public async Task<IResult> RegisterUserAsync([FromBody] UserCreateDto userCreateDto)
        {
            var registerResult = await _userAuthDomainServiceProxy.CreateUserAsync(userCreateDto);

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
        public async Task<IResult> LoginUserAsync([FromBody] UserLoginDto userLoginDto)
        {
            var signInResult = await _userAuthDomainServiceProxy.PasswordSignInAsync(userLoginDto);

            if (!signInResult.Succeeded)
            {
                return new Result<string> {State = ResultStateEnum.Failed};
            }
           
            var userId = await _userAuthDomainServiceProxy.GetUserIdAsync(userLoginDto.UserName);
            var userToken = _oAuthService.GetUserAuthToken(userLoginDto.UserName, userId);

            return new Result<string> {Content = userToken};
        }
    }
}
