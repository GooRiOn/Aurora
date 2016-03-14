using System.Threading.Tasks;
using Aurora.Infrastructure.Models;
using Aurora.Services.Services.Interfaces;
using Microsoft.AspNet.Mvc;

namespace Aurora.Web.Controllers
{
    [Route("api/accounts")]
    public class AccountController : Controller
    {
        private readonly IUserAuthService _userAuthService;

        public AccountController(IUserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }

        [HttpPost("register")]
        public async Task RegisterUserAsync([FromBody] UserCreateModel userCreateModel)
        {
            var registerResult = await _userAuthService.CreateUserAsync(userCreateModel);

            if (registerResult.Succeeded)
            {
                 var signInResult = await _userAuthService.PasswordSignInAsync(userCreateModel);
            }
        }
    }
}
