using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aurora.DataAccess.AppBuild;
using Autofac;
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
