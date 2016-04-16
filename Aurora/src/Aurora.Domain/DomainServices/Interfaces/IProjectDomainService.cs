using System;
using System.Threading.Tasks;
using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Models.WriteModels;

namespace Aurora.Domain.DomainServices.Interfaces
{
    public interface IProjectDomainService : IEntityService<ProjectEntity>
    {
        void CreateProject(ProjectCreateWriteModel project, string creatorId);
        Task ActivateProjectMemberAsync(Guid memberToken, string userId);
        void SetDefaultUserProject(int projectId, string userId);
    }
}