using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aurora.DataAccess.Entities;
using Aurora.DataAccess.Interfaces;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Extensions;
using Aurora.Infrastructure.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;
using Aurora.Infrastructure.Models.WriteModels;
using Microsoft.Data.Entity;

namespace Aurora.Domain.DomainServices
{
    public class BacklogItemDomainService : EntityService<BacklogItemEntity>, IBacklogItemDomainService
    {
        public BacklogItemDomainService(IRepositoryFactory<BacklogItemEntity> repositoryFactory, IUnitOfWork unitOfWork) 
            : base(repositoryFactory, unitOfWork)
        {
        }

        public async Task<IEnumerable<BacklogItemReadModel>> GetProjectBacklogItemsAsync(int projectId)
        {
            return await ReadRepository.NoTrackedQuery.Where(b => b.IsActive && b.Sprint.ProjectId == projectId).AsReadModel().ToListAsync();
        }

        public void AddBacklogItem(BacklogItemEntity backlogItem)
        {
            WriteRepository.Add(backlogItem);
        }

        public void UpdateBacklogItem(BacklogItemEntity backlogItemEntity)
        {
            WriteRepository.Update(backlogItemEntity);
        }

        public async Task DeleteBacklogItemAsync(int backlogItemId)
        {
            var backlogItem = await ReadRepository.Query.SingleOrDefaultAsync(b => b.Id == backlogItemId);
            WriteRepository.Delete(backlogItem);
        }
    }
}