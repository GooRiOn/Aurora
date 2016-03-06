using Autofac;

namespace Aurora.Web.DependencyInjection
{
    public class Registration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new Services.DependencyInjection.Registration());
        }
    }
}
