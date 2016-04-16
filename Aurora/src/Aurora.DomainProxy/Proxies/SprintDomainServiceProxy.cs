using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Interfaces;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.DomainProxy.Proxies
{
    public class SprintDomainServiceProxy : BaseProxy, ISprintDomainServiceProxy
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IDomainServiceFactory<ISprintDomainService> _sprintDomainServiceFactory;

        public SprintDomainServiceProxy(IUnitOfWorkFactory unitOfWorkFactory, IDomainServiceFactory<ISprintDomainService> sprintDomainServiceFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _sprintDomainServiceFactory = sprintDomainServiceFactory;
        }
    }
}
