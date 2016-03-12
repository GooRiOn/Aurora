using Aurora.Domain.AppBuild;
using Autofac;
using Microsoft.AspNet.Builder;

namespace Aurora.Services.AppBuild
{
    public static class AppBuild
    {
        public static void OnServicesBuild(this IApplicationBuilder app, IContainer container)
        {
            app.OnDomainBuild(container);
        }
    }
}
