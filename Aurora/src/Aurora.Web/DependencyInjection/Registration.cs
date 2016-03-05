using System;
using Aurora.Infrastructure.DependencyInjection;
using Aurora.Infrastructure.DependencyInjection.Initerfaces;
using Autofac;

namespace Aurora.Web.DependencyInjection
{
    public class Registration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new Domain.DependencyInjection.Registration());
        }
    }
}
