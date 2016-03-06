using System.Threading.Tasks;
using Aurora.DataAccess.Interfaces;
using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Infrastructure.Entities.Interfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.Domain.DomainServices
{
    public abstract class EntityService<TEntity,TRepo, TKey> : IEntityService<TEntity,TKey> 
        where TEntity : class, IInternalEntity<TKey> where TRepo : IGenericRepository<TEntity, TKey>
    {
        protected TRepo Repository { get; }

        protected EntityService(IRepositoryFactory<TRepo> repositoryFactory, IUnitOfWork unitOfWork)
        {
            Repository = repositoryFactory.Get(unitOfWork);
        } 

        public TEntity Add(TEntity entity)
        {
            return Repository.Add(entity);
        }

        public void Update(TEntity entity)
        {
            Repository.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            Repository.Delete(entity);
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await Repository.GetByIdAsync(id);
        }
    }
}
