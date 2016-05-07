using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;

namespace Aurora.DomainProxy.Proxies.Interfaces
{
    public interface IUserDomainServiceProxy : IBaseProxy
    {
        Task<UserSelfInfoReadModel> GetUserSelfInfoAsync(string userId);
        Task<IPagedResult<UserReadModel>> GetUsersPageAsync(int pageNumber, int pageSize);
        Task<IResult> LockUserAsync(string userId);
        Task<IResult> UnlockUserAsync(string userId);
        Task<IResult> DeleteUserAsync(string userId);
        Task<IEnumerable<UserReadModel>> FindUsersByPhraseAsync(string searchPhrase);
        Task<byte[]> GetUserGravatarAsync(string userName);
    }
}