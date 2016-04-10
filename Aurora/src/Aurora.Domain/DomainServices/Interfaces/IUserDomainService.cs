using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;

namespace Aurora.Domain.DomainServices.Interfaces
{
    public interface IUserDomainService : IEntityService<UserEntity>
    {
        Task<IPagedResult<UserReadModel>> GetUsersPageAsync(int pageNumber, int pageSize);
        Task LockUser(string userId);
        Task UnlockUser(string userId);
        Task DeleteUser(string userId);
        Task<IEnumerable<UserReadModel>> FindUsersByPhraseAsync(string searchPhrase);
        Task<byte[]> GetUserGravatarAsync(string userName);
    }
}