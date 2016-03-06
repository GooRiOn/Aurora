using System.Linq;
using Aurora.DataAccess.Interfaces;
using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Infrastructure.Entities;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.Domain.DomainServices
{
    public class UserDomainService : EntityService<UserEntity, IUserRepository, string>, IUserDomainService
    {
        public UserDomainService(IRepositoryFactory<IUserRepository> repositoryFactory, IUnitOfWork unitOfWork)
            : base(repositoryFactory, unitOfWork)
        {

        }

        public int Test()
        {
            return Repository.Query.Count();
        }
    }
}
