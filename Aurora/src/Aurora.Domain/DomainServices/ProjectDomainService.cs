using Aurora.DataAccess.Entities;
using Aurora.DataAccess.Interfaces;
using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.Domain.DomainServices
{
    public class ProjectDomainService : EntityService<ProjectEntity,IProjectRepository,int>, IProjectDomainService
    {
        public ProjectDomainService(IRepositoryFactory<IProjectRepository> repositoryFactory, IUnitOfWork unitOfWork) 
            : base(repositoryFactory, unitOfWork)
        {
        }
    }
}
