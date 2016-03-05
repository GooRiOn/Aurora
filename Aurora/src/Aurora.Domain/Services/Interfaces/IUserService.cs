using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Infrastructure.Entities;

namespace Aurora.Domain.Services.Interfaces
{
    public interface IUserService : IEntityService<UserEntity,string>
    {
         
    }
}