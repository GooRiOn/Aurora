using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;
using Aurora.Infrastructure.Models.WriteModels;

namespace Aurora.DomainProxy.Proxies.Interfaces
{
    public interface IBacklogItemDomainServiceProxy : IBaseProxy
    {
        Task<IEnumerable<BacklogItemReadModel>> GetProjectBacklogItemsAsync(int projectId);
        Task<IResult> CreateBacklogItemAsync(BacklogItemWriteModel backlogItem);
        Task<IResult> UpdateBacklogItemAsync(BacklogItemWriteModel backlogItemEntity);
        Task<IResult> DeleteBacklogItemAsync(int backlogItemId);
    }
}