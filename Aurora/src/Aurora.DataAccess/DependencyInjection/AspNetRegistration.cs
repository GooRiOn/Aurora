﻿using Aurora.DataAccess.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora.DataAccess.DependencyInjection
{
    public static class AspNetRegistration
    {
        public static void Register(IServiceCollection services)
        {
            services.AddIdentity<UserEntity,IdentityRole>(options =>
            {
                options.Password.RequireNonLetterOrDigit = false;
                options.Password.RequireUppercase = false;
                options.Cookies.ApplicationCookie.AutomaticChallenge = false;

            }).AddEntityFrameworkStores<AuroraContext>().AddDefaultTokenProviders();
        }
    }
}
