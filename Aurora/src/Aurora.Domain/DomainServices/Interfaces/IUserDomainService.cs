using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;

namespace Aurora.Domain.DomainServices.Interfaces
{
    public interface IUserDomainService : IEntityService<UserEntity>
    {
        Task<UserSelfInfoReadModel> GetUserSelfInfoAsync(string userId);
        Task<IPagedResult<UserReadModel>> GetUsersPageAsync(int pageNumber, int pageSize);
        Task LockUserAsync(string userId);
        Task UnlockUserAsync(string userId);
        Task DeleteUserAsync(string userId);
        Task<IEnumerable<UserReadModel>> FindUsersByPhraseAsync(string searchPhrase);
        Task<byte[]> GetUserGravatarAsync(string userName);
    }
}