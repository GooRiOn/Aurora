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
    public class SprintDomainServiceProxy : BaseProxy, ISprintDomainServiceProxy
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IDomainServiceFactory<ISprintDomainService> _sprintDomainServiceFactory;

        public SprintDomainServiceProxy(IUnitOfWorkFactory unitOfWorkFactory, IDomainServiceFactory<ISprintDomainService> sprintDomainServiceFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _sprintDomainServiceFactory = sprintDomainServiceFactory;
        }

        public async Task<IEnumerable<SprintReadModel>> GetProjectSprintsAsync(int projectId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var sprintDomainService = _sprintDomainServiceFactory.Get(unitOfWork);
                return await sprintDomainService.GetProjectSprintsAsync(projectId);
            }
        }

        public async Task<IResult> CreateSprintAsync(SprintWriteModel sprint)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get(false))
            {
                var sprintDomainService = _sprintDomainServiceFactory.Get(unitOfWork);
                var sprintEntity = sprint.AsEntity();
                sprintDomainService.CreateSprint(sprintEntity);

                return await CreateResultAsync(unitOfWork);
            }
        }

        public async Task<IResult> UpdateSprintAsync(SprintWriteModel sprint)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get(false))
            {
                var sprintDomainService = _sprintDomainServiceFactory.Get(unitOfWork);
                var sprintEntity = sprint.AsEntity();
                sprintDomainService.UpdateSprint(sprintEntity);

                return await CreateResultAsync(unitOfWork);
            }
        }

        public async Task<IResult> DeleteSprintAsync(int sprintId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get(false))
            {
                var sprintDomainService = _sprintDomainServiceFactory.Get(unitOfWork);
                await sprintDomainService.DeleteSprintAsync(sprintId);
                return await CreateResultAsync(unitOfWork);
            }
        }
    }
}
