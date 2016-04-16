using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.DataAccess.Entities;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Interfaces;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;

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

        public Task<IEnumerable<SprintReadModel>> GetProjectSprints(string projectId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> CreateSprintAsync(SprintEntity sprint)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> UpdateSprintAsync(SprintEntity sprint)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> DeleteSprintAsync(int sprintId)
        {
            throw new System.NotImplementedException();
        }
    }
}
