using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Models.ReadModels;

namespace Aurora.Domain.DomainServices.Interfaces
{
    public interface IBacklogItemDomainService : IEntityService<BacklogItemEntity>
    {
        Task<IEnumerable<BacklogItemReadModel>> GetProjectBacklogItemsAsync(int projectId);
        void CreateBacklogItem(BacklogItemEntity backlogItem);
        void UpdateBacklogItem(BacklogItemEntity backlogItemEntity);
        Task DeleteBacklogItemAsync(int backlogItemId);
    }
}