using System.Linq;
using System.Security.Claims;
using Aurora.DomainProxy.Proxies.Interfaces;
using Microsoft.AspNet.Authorization;

namespace Aurora.Web.Filters
{
    public class OnlyAdminRequirement : AuthorizationHandler<OnlyAdminRequirement>, IAuthorizationRequirement
    {
        private readonly IUserAuthDomainServiceProxy _userAuthDomainServiceProxy;

        public OnlyAdminRequirement(IUserAuthDomainServiceProxy userAuthDomainServiceProxy)
        {
            _userAuthDomainServiceProxy = userAuthDomainServiceProxy;
        }

        protected override void Handle(AuthorizationContext context, OnlyAdminRequirement requirement)
        {
            var claimsIdentoty = (ClaimsIdentity)context.User.Identity;
            var userClaim = claimsIdentoty.Claims.FirstOrDefault(c => c.Type == "UserId");

            var userId = userClaim?.Value;

            var user = _userAuthDomainServiceProxy.GetUserSelfInfoAsync(userId).Result;

            if (!user.Roles.Any(r => r == "Admin"))
                context.Fail();
        }
    }
}
