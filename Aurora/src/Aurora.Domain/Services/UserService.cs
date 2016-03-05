using Aurora.DataAccess.Interfaces;
using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Domain.Services.Interfaces;
using Aurora.Infrastructure.Entities;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.Domain.Services
{
    public class UserService : EntityService<UserEntity,IUserRepository,string>, IUserService
    {
        public UserService(IRepositoryFactory<IUserRepository> repositoryFactory, IUnitOfWork unitOfWork)
            :base(repositoryFactory,unitOfWork)
        {
            
        }
    }
}
