using Microsoft.AspNet.Authorization;

namespace Aurora.Web.Auth
{
    public class OnlyRoleRequirement : AuthorizationHandler<OnlyRoleRequirement>, IAuthorizationRequirement
    {
        private readonly string _roleName;

        public OnlyRoleRequirement(string roleName)
        {
            _roleName = roleName;
        }

        protected override void Handle(AuthorizationContext context, OnlyRoleRequirement requirement)
        {
            if (context.User.IsInRole(_roleName))
            {
                context.Succeed(requirement);
                return;
            }

            context.Fail();
        }
    }
}
