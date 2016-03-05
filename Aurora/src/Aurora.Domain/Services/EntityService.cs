using System.Threading.Tasks;
using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Domain.Services.Interfaces;
using Aurora.Infrastructure.Entities.Interfaces;

namespace Aurora.Domain.Services
{
    public abstract class EntityService<TEntity,TRepo, TKey> : IEntityService<TEntity,TRepo,TKey> 
        where TEntity : class, IInternalEntity<TKey> where TRepo : IGenericRepository<TEntity, TKey>
    {
        public TRepo Repository { get; }

        protected EntityService(TRepo repository)
        {
            Repository = repository;
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
