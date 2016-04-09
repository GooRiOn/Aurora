using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aurora.DataAccess.Interfaces;
using Aurora.DataAccess.Repositories.Interfaces;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.DataAccess.Entities;
using Aurora.DataAccess.Entities.Interfaces;
using Aurora.Domain.DomainObjects;
using Aurora.Domain.Extensions;
using Aurora.Infrastructure.Data;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Interfaces;
using Microsoft.Data.Entity;

namespace Aurora.Domain.DomainServices
{
    public class UserDomainService : EntityService<UserEntity, IUserRepository, string>, IUserDomainService
    {
        public UserDomainService(IRepositoryFactory<IUserRepository> repositoryFactory, IUnitOfWork unitOfWork)
            : base(repositoryFactory, unitOfWork)
        {

        }

        public async Task<IPagedResult<UserDomainObject>> GetUsersPageAsync(int pageNumber, int pageSize)
        {
            var qUsers = Repository.Query;
            var result = await qUsers.AsDomainObject().Skip(pageNumber - 1).Take(pageSize).ToListAsync();
            var usersNumber = await qUsers.CountAsync();

            return new PagedResult<UserDomainObject>
            {
                TotalPages = GetPagedResultTotalPages(usersNumber,pageSize),
                Content = result
            };
        }

        public async Task LockUser(string userId)
        {
            var user = await Repository.Query.SingleOrDefaultAsync(u => u.Id == userId);
            var lockableUser = (ILockable) user;

            lockableUser.Lock();
        }

        public async Task UnlockUser(string userId)
        {
            var user = await Repository.Query.SingleOrDefaultAsync(u => u.Id == userId);
            var lockableUser = (ILockable)user;

            lockableUser.Unlock();
        }

        public async Task DeleteUser(string userId)
        {
            var user = await Repository.Query.SingleOrDefaultAsync(u => u.Id == userId);
            var softDeletableUser = (ISoftDeletable)user;

            softDeletableUser.Delete();
        }

        public async Task<IEnumerable<UserDomainObject>> FindUsersByPhraseAsync(string searchPhrase)
        {
            return await Repository.Query.Where(u => u.UserName.Contains(searchPhrase) || u.Email.Contains(searchPhrase)).AsDomainObject().ToListAsync();
        }

        public async Task<byte[]> GetUserGravatarAsync(string userName)
        {
            return await Repository.Query.Where(u => u.UserName == userName).Select(u => u.Gravatar).SingleOrDefaultAsync();
        }
    }
}
