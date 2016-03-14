using System.Threading.Tasks;
using Aurora.DataAccess.Entities.Interfaces;

namespace Aurora.Domain.DomainServices.Interfaces
{
    public interface IEntityService<TEntity, in TKey> where TEntity : class, IInternalEntity<TKey>
    {
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> GetByIdAsync(TKey id);
    }
}