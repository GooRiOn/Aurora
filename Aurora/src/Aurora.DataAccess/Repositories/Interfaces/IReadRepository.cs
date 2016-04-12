using System.Linq;
using Aurora.DataAccess.Entities.Interfaces;

namespace Aurora.DataAccess.Repositories.Interfaces
{
    public interface IReadRepository<out TEntity> where TEntity : class, IInternalEntity
    {
        IQueryable<TEntity> Query { get; }
        IQueryable<TEntity> NoTrackedQuery { get; }
    }
}
