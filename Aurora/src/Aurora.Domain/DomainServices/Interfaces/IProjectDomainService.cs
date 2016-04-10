using System.Collections.Generic;
using Aurora.DataAccess.Entities;
using Aurora.Domain.DomainObjects;

namespace Aurora.Domain.DomainServices.Interfaces
{
    public interface IProjectDomainService : IEntityService<ProjectEntity>
    {
        void CreateProject(ProjectCreateDomainObject project);
    }
}