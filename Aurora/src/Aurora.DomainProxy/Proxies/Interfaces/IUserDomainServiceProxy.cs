using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;

namespace Aurora.DomainProxy.Proxies.Interfaces
{
    public interface IUserDomainServiceProxy : IBaseProxy
    {
        Task<IPagedResult<UserReadModel>> GetUsersPageAsync(int pageNumber, int pageSize);
        Task<IResult> LockUser(string userId);
        Task<IResult> UnlockUser(string userId);
        Task<IResult> DeleteUser(string userId);
        Task<IEnumerable<UserReadModel>> FindUsersByPhraseAsync(string searchPhrase);
        Task<byte[]> GetUserGravatarAsync(string userName);
    }
}