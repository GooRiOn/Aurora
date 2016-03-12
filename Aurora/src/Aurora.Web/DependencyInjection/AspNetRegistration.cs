using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Web.DependencyInjection
{
    public static class AspNetRegistration
    {
        public static void Register(IServiceCollection services)
        {
            Services.DependencyInjection.AspNetRegistration.Register(services);
        }
    }
}
