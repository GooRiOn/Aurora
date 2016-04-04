using Aurora.Domain.DomainServices;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Interfaces;
using Autofac;

namespace Aurora.Domain.DependencyInjection
{
    public class Registration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataAccess.DependencyInjection.Registration());

            builder.RegisterGeneric(typeof (DomainDomainServiceFactory<>)).As(typeof (IDomainServiceFactory<>));
            builder.RegisterType<UserDomainService>().As<IUserDomainService>();
            builder.RegisterType<UserAuthDomainService>().As<IUserAuthDomainService>();
            builder.RegisterType<ProjectDomainService>().As<IProjectDomainService>();
        }
    }
}
