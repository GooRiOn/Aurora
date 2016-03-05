using Aurora.Domain.Interfaces;
using Aurora.Domain.Services;
using Aurora.Domain.Services.Interfaces;
using Autofac;

namespace Aurora.Domain.DependencyInjection
{
    public class Registration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataAccess.DependencyInjection.Registration());

            builder.RegisterGeneric(typeof (ServiceFactory<>)).As(typeof (IServiceFactory<>));
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}
