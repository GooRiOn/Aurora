using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.DataAccess.Entities;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Interfaces;
using Aurora.DomainProxy.Mappings;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;
using Aurora.Infrastructure.Models.WriteModels;

namespace Aurora.DomainProxy.Proxies
{
    public class BacklogItemDomainServiceProxy : BaseProxy, IBacklogItemDomainServiceProxy
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IDomainServiceFactory<IBacklogItemDomainService> _backlogDomainServiceFactory; 

        public BacklogItemDomainServiceProxy(IUnitOfWorkFactory unitOfWorkFactory, IDomainServiceFactory<IBacklogItemDomainService> backlogDomainServiceFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _backlogDomainServiceFactory = backlogDomainServiceFactory;
        }

        public async Task<IEnumerable<BacklogItemReadModel>> GetProjectBacklogItemsAsync(int projectId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var backlogItemDomainService = _backlogDomainServiceFactory.Get(unitOfWork);
                return await backlogItemDomainService.GetProjectBacklogItemsAsync(projectId);
            }
        }

        public async Task<IResult> CreateBacklogItemAsync(BacklogItemWriteModel backlogItem)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var backlogItemDomainService = _backlogDomainServiceFactory.Get(unitOfWork);

                var backlogItemEntity = backlogItem.AsEntity();
                backlogItemDomainService.CreateBacklogItem(backlogItemEntity);

                return await CreateResultAsync(unitOfWork);
            }
        }

        public async Task<IResult> UpdateBacklogItem(BacklogItemWriteModel backlogItem)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var backlogItemDomainService = _backlogDomainServiceFactory.Get(unitOfWork);

                var backlogItemEntity = backlogItem.AsEntity();
                backlogItemDomainService.UpdateBacklogItem(backlogItemEntity);

                return await CreateResultAsync(unitOfWork);
            }
        }

        public async Task<IResult> DeleteBacklogItemAsync(int backlogItemId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var backlogItemDomainService = _backlogDomainServiceFactory.Get(unitOfWork);
                await backlogItemDomainService.DeleteBacklogItemAsync(backlogItemId);

                return await CreateResultAsync(unitOfWork);
            }
        }
    }
}