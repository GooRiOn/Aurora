using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Services.DependencyInjection
{
    public static class AspNetRegistration
    {
        public static void Register(IServiceCollection services)
        {
            Domain.DependencyInjection.AspNetRegistration.Register(services);
        }
    }
}
