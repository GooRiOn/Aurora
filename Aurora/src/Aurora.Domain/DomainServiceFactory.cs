using Aurora.Domain.Interfaces;
using Aurora.Infrastructure.DependencyInjection.Initerfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.Domain
{
    public class DomainServiceFactory<TService> : IDomainServiceFactory<TService>
    {
        private readonly ICustomDependencyResolver _resolver;

        public DomainServiceFactory(ICustomDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public TService Get(IUnitOfWork unitOfWork)
        {
            return _resolver.Resolve<TService, IUnitOfWork>("unitOfWork", unitOfWork);
        }
    }
}
