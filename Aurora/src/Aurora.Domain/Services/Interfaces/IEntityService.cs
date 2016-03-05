using System.Threading.Tasks;
using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Infrastructure.Entities.Interfaces;

namespace Aurora.Domain.Services.Interfaces
{
    public interface IEntityService<TEntity, out TRepo, in TKey> where TEntity : class, IInternalEntity<TKey> where TRepo : IGenericRepository<TEntity, TKey>
    {
        TRepo Repository { get; }

        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> GetByIdAsync(TKey id);
    }
}