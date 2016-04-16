using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aurora.DataAccess.Entities;
using Aurora.DataAccess.Interfaces;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Extensions;
using Aurora.Infrastructure.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;
using Microsoft.Data.Entity;

namespace Aurora.Domain.DomainServices
{
    public class SprintDomainService : EntityService<SprintEntity>, ISprintDomainService
    {
        public SprintDomainService(IRepositoryFactory<SprintEntity> repositoryFactory, IUnitOfWork unitOfWork) 
            : base(repositoryFactory, unitOfWork)
        {
        }

        public async Task<IEnumerable<SprintReadModel>> GetProjectSprints(string projectId)
        {
            return await ReadRepository.NoTrackedQuery.Where(s => s.IsActive).AsReadModel().ToListAsync();
        }

        public void CreateSprint(SprintEntity sprint)
        {
            WriteRepository.Add(sprint);
        }

        public void UpdateSprint(SprintEntity sprint)
        {
            WriteRepository.Update(sprint);
        }

        public async Task DeleteSprintAsync(int sprintId)
        {
            var sprint = await ReadRepository.Query.SingleOrDefaultAsync(s => s.Id == sprintId);
            WriteRepository.Delete(sprint);
        }
    }
}
