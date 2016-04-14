using System;
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

        public async Task<IResult> CreateProjectAsync(ProjectCreateWriteModel project, string creatorId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get(false))
            {
                var projectDomainService = _projectDomainServiceFactory.Get(unitOfWork);

                projectDomainService.CreateProject(project, creatorId);

                return await CreateResultAsync(unitOfWork);
            }
        }

        public async Task<IResult> ActivateProjectMemberAsync(Guid memberToken, string userId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get(false))
            {
                var projectDomainService = _projectDomainServiceFactory.Get(unitOfWork);

                await projectDomainService.ActivateProjectMemberAsync(memberToken, userId);
                return await CreateResultAsync(unitOfWork);
            }
        }
    }
}
