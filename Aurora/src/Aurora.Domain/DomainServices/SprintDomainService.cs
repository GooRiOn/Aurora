using Aurora.DataAccess.Entities;
using Aurora.DataAccess.Interfaces;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.Domain.DomainServices
{
    public class SprintDomainService : EntityService<SprintEntity>, ISprintDomainService
    {
        public SprintDomainService(IRepositoryFactory<SprintEntity> repositoryFactory, IUnitOfWork unitOfWork) 
            : base(repositoryFactory, unitOfWork)
        {
        }
    }
}
