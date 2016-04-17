using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Models.ReadModels;

namespace Aurora.Domain.DomainServices.Interfaces
{
    public interface ISprintDomainService : IEntityService<SprintEntity>
    {
        Task<IEnumerable<SprintReadModel>> GetProjectSprintsAsync(int projectId);
        void CreateSprint(SprintEntity sprint);
        void UpdateSprint(SprintEntity sprint);
        Task DeleteSprintAsync(int sprintId);
    }
}