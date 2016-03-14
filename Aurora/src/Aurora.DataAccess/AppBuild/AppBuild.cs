using System;
using Aurora.DataAccess.Entities;
using Autofac;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Aurora.DataAccess.AppBuild
{
    public static class AppBuild
    {
        public static void OnDataAccessBuild(this IApplicationBuilder app, IContainer container)
        {
           var userManager = container.Resolve<UserManager<UserEntity>>();
           var roleManger = container.Resolve<RoleManager<IdentityRole>>(); 
           var context = container.Resolve<AuroraContext>();
           new AuroraContextSeed().Seed(context, userManager, roleManger).Wait();
        }
    }
}
