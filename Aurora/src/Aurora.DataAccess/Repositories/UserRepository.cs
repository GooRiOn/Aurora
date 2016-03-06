using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Infrastructure.Entities;

namespace Aurora.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<UserEntity, string>, IUserRepository
    {
        public UserRepository(AuroraContext context)
            :base(context)
        {
        }
    }
}
