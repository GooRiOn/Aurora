using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Domain.DependencyInjection
{
    public static class AspNetRegistration
    {
        public static void Register(IServiceCollection services)
        {
            DataAccess.DependencyInjection.AspNetRegistration.Register(services);
        }
    }
}
