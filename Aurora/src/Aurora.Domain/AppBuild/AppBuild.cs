using Aurora.DataAccess.AppBuild;
using Autofac;
using AutoMapper;
using Microsoft.AspNet.Builder;

namespace Aurora.Domain.AppBuild
{
    public static class AppBuild
    {
        public static void OnDomainBuild(this IApplicationBuilder app, IContainer container)
        {
            app.OnDataAccessBuild(container);
        }
    }
}
