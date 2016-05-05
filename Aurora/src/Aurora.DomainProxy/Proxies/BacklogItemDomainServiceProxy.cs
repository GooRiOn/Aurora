using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Interfaces;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Interfaces;

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
    }
}