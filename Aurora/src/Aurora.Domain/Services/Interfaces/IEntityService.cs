using System.Threading.Tasks;
using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Infrastructure.Entities.Interfaces;

namespace Aurora.Domain.Services.Interfaces
{
    public interface IEntityService<TEntity, in TKey> where TEntity : class, IKeyedInternalEntity<TKey>
    {
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> GetByIdAsync(TKey id);
    }
}