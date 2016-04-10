using System.Threading.Tasks;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Interfaces;
using Aurora.DomainProxy.Dtos;
using Aurora.DomainProxy.Mappings;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.DomainProxy.Proxies
{
    public class ProjectDomainServiceProxy : BaseProxy, IProjectDomainServiceProxy
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IDomainServiceFactory<IProjectDomainService> _projectDomainServiceFactory; 

        public ProjectDomainServiceProxy(IUnitOfWorkFactory unitOfWorkFactory, IDomainServiceFactory<IProjectDomainService> projectDomainServiceFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _projectDomainServiceFactory = projectDomainServiceFactory;
        }

        public async Task<IResult> CreateProjectAsync(ProjectCreateDto project)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get(false))
            {
                var projectDomainService = _projectDomainServiceFactory.Get(unitOfWork);
                var projectDomainObject = project.AsDomainObject();

                projectDomainService.CreateProject(projectDomainObject);

                return await CreateResultAsync(unitOfWork);
            }
        }
    }
}
