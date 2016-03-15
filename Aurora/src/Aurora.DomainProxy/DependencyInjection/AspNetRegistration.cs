using Aurora.DomainProxy.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora.DomainProxy.DependencyInjection
{
    public static class AspNetRegistration
    {
        public static void Register(IServiceCollection services)
        {
            Domain.DependencyInjection.AspNetRegistration.Register(services);

            ToDomainObjectMappings.RegisterMaps();
            ToDtoMappings.RegisterMaps();
            
        }
    }
}