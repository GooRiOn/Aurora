using System.Collections.Generic;
using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Models.WriteModels;

namespace Aurora.Domain.DomainServices.Interfaces
{
    public interface IProjectDomainService : IEntityService<ProjectEntity>
    {
        void CreateProject(ProjectCreateWriteModel project);
    }
}