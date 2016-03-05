using Autofac;

namespace Aurora.Domain.DependencyInjection
{
    public class Registration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataAccess.DependencyInjection.Registration());
        }
    }
}
