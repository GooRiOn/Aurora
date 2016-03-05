using System.Linq;
using System.Threading.Tasks;
using Aurora.Infrastructure.Entities.Interfaces;

namespace Aurora.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity, in TKey> where TEntity : class, IInternalEntity<TKey>
    {
        IQueryable<TEntity> Query { get; }
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> GetByIdAsync(TKey id);
    }
}