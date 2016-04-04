using Aurora.Domain.DomainServices;
using Aurora.Domain.Interfaces;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.DomainProxy.Proxies
{
    public class ProjectDomainServiceProxy : BaseProxy, IProjectDomainServiceProxy
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IDomainServiceFactory<ProjectDomainService> _projectDomainServiceFactory; 

        public ProjectDomainServiceProxy(IUnitOfWorkFactory unitOfWorkFactory, IDomainServiceFactory<ProjectDomainService> projectDomainServiceFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _projectDomainServiceFactory = projectDomainServiceFactory;
        }
    }
}
