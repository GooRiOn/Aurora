using Aurora.DataAccess.Entities;
using Aurora.Domain.DomainObjects;

namespace Aurora.Domain.DomainServices.Interfaces
{
    public interface IProjectDomainService : IEntityService<ProjectEntity,int>
    {
        void CreateProject(ProjectCreateDomainObject project);
    }
}