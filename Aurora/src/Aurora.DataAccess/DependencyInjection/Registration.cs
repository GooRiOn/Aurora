using Aurora.DataAccess.Interfaces;
using Aurora.DataAccess.Repositories;
using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Infrastructure.Interfaces;
using Autofac;

namespace Aurora.DataAccess.DependencyInjection
{
    public class Registration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuroraContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof (RepositoryFactory<>)).As(typeof (IRepositoryFactory<>));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
