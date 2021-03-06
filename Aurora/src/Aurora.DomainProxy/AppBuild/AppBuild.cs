﻿using Aurora.Domain.AppBuild;
using Aurora.DomainProxy.Mappings;
using Autofac;
using Microsoft.AspNet.Builder;

namespace Aurora.DomainProxy.AppBuild
{
    public static class AppBuild
    {
        public static void OnDomainProxyBuild(this IApplicationBuilder app, IContainer container)
        {
            app.OnDomainBuild(container);
         
            ToEntityMappings.RegisterMaps();
        }
    }
}