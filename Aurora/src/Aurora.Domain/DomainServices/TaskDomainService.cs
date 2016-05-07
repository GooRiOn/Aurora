using Aurora.DataAccess.Entities;
using Aurora.DataAccess.Interfaces;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.Domain.DomainServices
{
    public sealed class TaskDomainService : EntityService <TaskEntity>, ITaskDomainService
    {
        public TaskDomainService(IRepositoryFactory<TaskEntity> repositoryFactory, IUnitOfWork unitOfWork) : base(repositoryFactory, unitOfWork)
        {

        }
    }
}
