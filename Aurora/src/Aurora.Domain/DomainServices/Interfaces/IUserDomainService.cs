using System.Threading.Tasks;
using Aurora.DataAccess.Entities;
using Aurora.Domain.DomainObjects;
using Aurora.Infrastructure.Data.Interfaces;

namespace Aurora.Domain.DomainServices.Interfaces
{
    public interface IUserDomainService : IEntityService<UserEntity, string>
    {
        Task<IPagedResult<UserDomainObject>> GetUsersPageAsync(int pageNumber, int pageSize);
        Task LockUser(string userId);
        Task UnlockUser(string userId);
        Task DeleteUser(string userId);
    }
}