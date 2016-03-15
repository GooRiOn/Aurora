using System.Threading.Tasks;
using Aurora.DomainProxy.Dtos;
using Aurora.DomainProxy.Proxies.Interfaces;
using Microsoft.AspNet.Mvc;

namespace Aurora.Web.Controllers
{
    [Route("api/accounts")]
    public class AccountController : Controller
    {
        private readonly IUserAuthDomainServiceProxy _userAuthDomainServiceProxy;

        public AccountController(IUserAuthDomainServiceProxy userAuthDomainServiceProxy)
        {
            _userAuthDomainServiceProxy = userAuthDomainServiceProxy;
        }

        [HttpPost("register")]
        public async Task RegisterUserAsync([FromBody] UserCreateDto userCreateDto)
        {
            var registerResult = await _userAuthDomainServiceProxy.CreateUserAsync(userCreateDto);

            if (registerResult.Succeeded)
            {
                 var signInResult = await _userAuthDomainServiceProxy.PasswordSignInAsync(userCreateDto);
            }
        }
    }
}
