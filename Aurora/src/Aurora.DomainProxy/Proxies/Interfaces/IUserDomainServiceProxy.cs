using System.Threading.Tasks;
using Aurora.DomainProxy.Dtos;
using Aurora.Infrastructure.Data.Interfaces;

namespace Aurora.DomainProxy.Proxies.Interfaces
{
    public interface IUserDomainServiceProxy
    {
        Task<IPagedResult<UserDto>> GetUsersPageAsync(int pageNumber, int pageSize);
        Task<IResult> LockUser(string userId);
        Task<IResult> UnlockUser(string userId);
        Task<IResult> DeleteUser(string userId);
    }
}