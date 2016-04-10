using Aurora.DataAccess.Entities.Interfaces;
using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.DataAccess.Interfaces
{
    public interface IRepositoryFactory<TEntity> where TEntity : class, IInternalEntity
    {
        IReadRepository<TEntity> GetRead(IUnitOfWork unitOfWork);
        IWriteRepository<TEntity> GetWrite(IUnitOfWork unitOfWork);
    }
}