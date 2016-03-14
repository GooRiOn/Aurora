using System.Linq;
using System.Threading.Tasks;
using Aurora.DataAccess.Interfaces;
using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.Domain.DomainServices
{
    public class UserDomainService : EntityService<UserEntity, IUserRepository, string>, IUserDomainService
    {
        public UserDomainService(IRepositoryFactory<IUserRepository> repositoryFactory, IUnitOfWork unitOfWork)
            : base(repositoryFactory, unitOfWork)
        {

        }
    }
}
