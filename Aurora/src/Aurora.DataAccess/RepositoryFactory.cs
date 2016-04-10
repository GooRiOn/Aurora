using Aurora.DataAccess.Entities.Interfaces;
using Aurora.DataAccess.Interfaces;
using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Infrastructure.DependencyInjection.Initerfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.DataAccess
{
    public class RepositoryFactory<TEntity> : IRepositoryFactory<TEntity> where TEntity : class, IInternalEntity
    {
        private ICustomDependencyResolver _resolver { get; set; }

        public RepositoryFactory(ICustomDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public IReadRepository<TEntity> GetRead(IUnitOfWork unitOfWork)
        {
            var contextGetter = (IContextGetter)unitOfWork;
            return _resolver.Resolve<IReadRepository<TEntity>, AuroraContext>("context",contextGetter.Context);
        }

        public IWriteRepository<TEntity> GetWrite(IUnitOfWork unitOfWork)
        {
            var contextGetter = (IContextGetter)unitOfWork;
            return _resolver.Resolve<IWriteRepository<TEntity>, AuroraContext>("context", contextGetter.Context);
        }
    }
}
