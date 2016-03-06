using Aurora.Domain.Interfaces;
using Aurora.Infrastructure.DependencyInjection.Initerfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.Domain
{
    public class DomainDomainServiceFactory<TService> : IDomainServiceFactory<TService>
    {
        private readonly ICustomDependencyResolver _resolver;

        public DomainDomainServiceFactory(ICustomDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public TService Get(IUnitOfWork unitOfWork)
        {
            return _resolver.Resolve<TService, IUnitOfWork>("unitOfWork",unitOfWork);
        }
    }
}
