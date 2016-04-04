using System.Linq;
using System.Security.Claims;
using Aurora.Infrastructure.Data;
using Aurora.Infrastructure.Data.Interfaces;
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

        protected IResult CreateResult(ResultStateEnum state = ResultStateEnum.Succeed, string[] errors = null)
        {
            return new Result
            {
                State = state,
                Errors = errors
            };
        }

    }
}
