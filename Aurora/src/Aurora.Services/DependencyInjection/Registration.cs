using Aurora.Services.Services;
using Aurora.Services.Services.Interfaces;
using Autofac;

namespace Aurora.Services.DependencyInjection
{
    public class Registration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new Domain.DependencyInjection.Registration());

            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}
