using Aurora.Domain.Interfaces;
using Aurora.Infrastructure.DependencyInjection.Initerfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.Domain
{
    public class ServiceFactory<TService> : IServiceFactory<TService>
    {
        private readonly ICustomDependencyResolver _resolver;

        public ServiceFactory(ICustomDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public TService Get(IUnitOfWork unitOfWork)
        {
            return _resolver.Resolve<TService, IUnitOfWork>("unitOfWork",unitOfWork);
        }
    }
}
