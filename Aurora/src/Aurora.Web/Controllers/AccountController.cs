using System.Threading.Tasks;
using Aurora.DomainProxy.Dtos;
using Aurora.DomainProxy.Proxies.Interfaces;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Aurora.Web.Controllers
{
    [Route("api/accounts"),Authorize("Bearer")]
    public class AccountController : Controller
    {
        private readonly IUserAuthDomainServiceProxy _userAuthDomainServiceProxy;

        public AccountController(IUserAuthDomainServiceProxy userAuthDomainServiceProxy)
        {
            _userAuthDomainServiceProxy = userAuthDomainServiceProxy;
        }

        [HttpPost("register"),AllowAnonymous]
        public async Task<string> RegisterUserAsync([FromBody] UserCreateDto userCreateDto)
        {
            var registerResult = await _userAuthDomainServiceProxy.CreateUserAsync(userCreateDto);

            if (registerResult.Succeeded)
            {
                 var signInResult = await _userAuthDomainServiceProxy.PasswordSignInAsync(userCreateDto);

                if (signInResult.Succeeded)
                {
                    var userToken = await _userAuthDomainServiceProxy.GetUserAuthToken(userCreateDto.UserName);
                    return userToken;
                }

                return string.Empty;
            }

            return string.Empty;
        }

        [HttpPost("test")]
        public void Test()
        {
            
        }
    }
}
