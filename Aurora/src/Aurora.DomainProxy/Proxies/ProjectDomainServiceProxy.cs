using System.Threading.Tasks;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Interfaces;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Interfaces;
using Aurora.Infrastructure.Models.WriteModels;

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

        public async Task<IResult> CreateProjectAsync(ProjectCreateWriteModel project)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get(false))
            {
                var projectDomainService = _projectDomainServiceFactory.Get(unitOfWork);

                projectDomainService.CreateProject(project);

                return await CreateResultAsync(unitOfWork);
            }
        }
    }
}
