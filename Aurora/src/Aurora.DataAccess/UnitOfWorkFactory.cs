using Aurora.Infrastructure.DependencyInjection.Initerfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.DataAccess
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private ICustomDependencyResolver _customResolver { get; }

        public UnitOfWorkFactory(ICustomDependencyResolver customResolver)
        {
            _customResolver = customResolver;
        }

        public IUnitOfWork Get()
        {
            return _customResolver.Resolve<IUnitOfWork>();
        }
    }
}
