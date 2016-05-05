using Aurora.DataAccess.Entities;
using Aurora.DataAccess.Interfaces;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.Domain.DomainServices
{
    public class BacklogItemDomainService : EntityService<BacklogItemEntity>, IBacklogItemDomainService
    {
        public BacklogItemDomainService(IRepositoryFactory<BacklogItemEntity> repositoryFactory, IUnitOfWork unitOfWork) 
            : base(repositoryFactory, unitOfWork)
        {
        }
    }
}