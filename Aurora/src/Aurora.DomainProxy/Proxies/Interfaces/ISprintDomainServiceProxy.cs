using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;
using Aurora.Infrastructure.Models.WriteModels;

namespace Aurora.DomainProxy.Proxies.Interfaces
{
    public interface ISprintDomainServiceProxy : IBaseProxy
    {
        Task<IEnumerable<SprintReadModel>> GetProjectSprintsAsync(int projectId);
        Task<IResult> CreateSprintAsync(SprintWriteModel sprint);
        Task<IResult> UpdateSprintAsync(SprintWriteModel sprint);
        Task<IResult> DeleteSprintAsync(int sprintId);
    }
}