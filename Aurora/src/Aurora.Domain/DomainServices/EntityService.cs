using System;
using System.Threading.Tasks;
using Aurora.DataAccess.Interfaces;
using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.DataAccess.Entities.Interfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.Domain.DomainServices
{
    public abstract class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class, IInternalEntity 
    {
        protected IReadRepository<TEntity> ReadRepository { get; }
        protected IWriteRepository<TEntity> WriteRepository { get; } 

        protected EntityService(IRepositoryFactory<TEntity> repositoryFactory, IUnitOfWork unitOfWork)
        {
            ReadRepository = repositoryFactory.GetRead(unitOfWork);
            WriteRepository = repositoryFactory.GetWrite(unitOfWork);
        } 

        public TEntity Add(TEntity entity)
        {
            return WriteRepository.Add(entity);
        }

        public void Update(TEntity entity)
        {
            WriteRepository.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            WriteRepository.Delete(entity);
        }

        protected int GetPagedResultTotalPages(int collection, int pageSize)
        {
            return (int) Math.Ceiling((decimal) collection/pageSize);
        }
    }
}
