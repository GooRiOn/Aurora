using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.DataAccess.Interfaces;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.DataAccess.Entities;
using Aurora.DataAccess.Entities.Interfaces;
using Aurora.Infrastructure.Data;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Interfaces;
using System.Linq;
using Aurora.Domain.Extensions;
using Aurora.Infrastructure.Models.ReadModels;
using Microsoft.Data.Entity;

namespace Aurora.Domain.DomainServices
{
    public class UserDomainService : EntityService<UserEntity>, IUserDomainService
    {
        public UserDomainService(IRepositoryFactory<UserEntity> repositoryFactory, IUnitOfWork unitOfWork)
            : base(repositoryFactory, unitOfWork)
        {

        }

        public async Task<IPagedResult<UserReadModel>> GetUsersPageAsync(int pageNumber, int pageSize)
        {
            var qUsers = ReadRepository.Query;
            var result = await qUsers.AsReadModel().Skip(pageNumber - 1).Take(pageSize).ToListAsync();
            var usersNumber = await qUsers.CountAsync();

            return new PagedResult<UserReadModel>
            {
                TotalPages = GetPagedResultTotalPages(usersNumber,pageSize),
                Content = result
            };
        }

        public async Task LockUser(string userId)
        {
            var user = await ReadRepository.Query.SingleOrDefaultAsync(u => u.Id == userId);
            var lockableUser = (ILockable) user;

            lockableUser.Lock();
        }

        public async Task UnlockUser(string userId)
        {
            var user = await ReadRepository.Query.SingleOrDefaultAsync(u => u.Id == userId);
            var lockableUser = (ILockable)user;

            lockableUser.Unlock();
        }

        public async Task DeleteUser(string userId)
        {
            var user = await ReadRepository.Query.SingleOrDefaultAsync(u => u.Id == userId);
            var softDeletableUser = (ISoftDeletable)user;

            softDeletableUser.Delete();
        }

        public async Task<IEnumerable<UserReadModel>> FindUsersByPhraseAsync(string searchPhrase)
        {
            return await ReadRepository.Query.Where(u => u.UserName.Contains(searchPhrase) || u.Email.Contains(searchPhrase)).AsReadModel().ToListAsync();
        }

        public async Task<byte[]> GetUserGravatarAsync(string userName)
        {
            return await ReadRepository.Query.Where(u => u.UserName == userName).Select(u => u.Gravatar).SingleOrDefaultAsync();
        }
    }
}
