using System.Linq;
using Aurora.DataAccess.Entities;
using Aurora.DataAccess.Interfaces;
using Aurora.Domain.DomainObjects;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.Domain.DomainServices
{
    public sealed class ProjectDomainService : EntityService<ProjectEntity>, IProjectDomainService
    {
        public ProjectDomainService(IRepositoryFactory<ProjectEntity> repositoryFactory, IUnitOfWork unitOfWork) 
            : base(repositoryFactory, unitOfWork)
        {
        }

        public void CreateProject(ProjectCreateDomainObject project)
        {
            var projectEntity = new ProjectEntity
            {
                Name = project.Name,
                Description = project.Description,
                Members = project.Members.Select(m => new UserProjectEntity
                {
                    UserId = m.Id
                }).ToList()
            };

            WriteRepository.Add(projectEntity);
        }
    }
}
