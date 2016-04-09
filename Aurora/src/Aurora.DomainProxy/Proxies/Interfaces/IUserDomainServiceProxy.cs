using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.DomainProxy.Dtos;
using Aurora.Infrastructure.Data.Interfaces;

namespace Aurora.DomainProxy.Proxies.Interfaces
{
    public interface IUserDomainServiceProxy : IBaseProxy
    {
        Task<IPagedResult<UserDto>> GetUsersPageAsync(int pageNumber, int pageSize);
        Task<IResult> LockUser(string userId);
        Task<IResult> UnlockUser(string userId);
        Task<IResult> DeleteUser(string userId);
        Task<IEnumerable<UserDto>> FindUsersByPhraseAsync(string searchPhrase);
        Task<byte[]> GetUserGravatarAsync(string userName);
    }
}