using System;
using System.Linq;
using System.Threading.Tasks;
using Aurora.DataAccess.Entities;
using Aurora.DataAccess.Interfaces;
using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Domain.DomainObjects;
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

        public void CreateProject(ProjectCreateDomainObject project)
        {
            var projectEntity = new ProjectEntity
            {
                Name = project.Name,
                Description = project.Description,
                Members = project.Members.Select(m => new UserProjectEntity
                {
                    UserId = m.Id,
                    MemberToken = Guid.NewGuid()
                }).ToList()
            };

            Repository.Add(projectEntity);
        }
    }
}
