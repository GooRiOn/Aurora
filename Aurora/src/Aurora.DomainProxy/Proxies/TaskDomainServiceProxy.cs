using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Interfaces;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.DomainProxy.Proxies
{
    public class TaskDomainServiceProxy : BaseProxy, ITaskDomainServiceProxy
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IDomainServiceFactory<ITaskDomainService> _taskDomainServiceFactory; 

        public TaskDomainServiceProxy(IUnitOfWorkFactory unitOfWorkFactory, IDomainServiceFactory<ITaskDomainService> taskDomainServiceFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _taskDomainServiceFactory = taskDomainServiceFactory;
        }
    }
}