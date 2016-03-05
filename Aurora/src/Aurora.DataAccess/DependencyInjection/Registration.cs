using Autofac;
using Microsoft.Data.Entity;

namespace Aurora.DataAccess.DependencyInjection
{
    public class Registration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuroraContext>().AsSelf().InstancePerRequest();
        }
    }
}
