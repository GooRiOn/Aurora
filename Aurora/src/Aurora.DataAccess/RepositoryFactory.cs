using Aurora.DataAccess.Interfaces;
using Aurora.Infrastructure.DependencyInjection.Initerfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.DataAccess
{
    public class RepositoryFactory<TRepo> : IRepositoryFactory<TRepo>
    {
        private ICustomDependencyResolver _resolver { get; set; }

        public RepositoryFactory(ICustomDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public TRepo Get(IUnitOfWork unitOfWork)
        {
            var contextGetter = (IContextGetter)unitOfWork;
            return _resolver.Resolve<TRepo, AuroraContext>("context",contextGetter.Context);
        }
    }
}
