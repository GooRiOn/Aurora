using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;

namespace Aurora.DomainProxy.Proxies.Interfaces
{
    public interface ISprintDomainServiceProxy : IBaseProxy
    {
        Task<IEnumerable<SprintReadModel>> GetProjectSprints(string projectId);
        Task<IResult> CreateSprintAsync(SprintEntity sprint);
        Task<IResult> UpdateSprintAsync(SprintEntity sprint);
        Task<IResult> DeleteSprintAsync(int sprintId);
    }
}