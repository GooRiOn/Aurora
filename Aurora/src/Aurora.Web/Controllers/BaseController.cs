using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Aurora.Web.Controllers
{
    [Authorize("Bearer")]
    public class BaseController : Controller
    {
        protected string GetUserId()
        {
            var claimsIdentoty = (ClaimsIdentity) User.Identity;
            var userClaim = claimsIdentoty.Claims.FirstOrDefault(c => c.Type == "UserId");

            return userClaim?.Value;
        }

    }
}
