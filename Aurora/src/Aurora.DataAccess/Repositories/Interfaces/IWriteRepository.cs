using Aurora.DataAccess.Entities.Interfaces;

namespace Aurora.DataAccess.Repositories.Interfaces
{
    public interface IWriteRepository<TEntity> where TEntity : class, IInternalEntity
    {
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}