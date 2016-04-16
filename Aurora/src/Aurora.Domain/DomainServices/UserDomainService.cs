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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Aurora.Domain.DomainServices
{
    public class UserDomainService : EntityService<UserEntity>, IUserDomainService
    {
        private readonly RoleManager<IdentityRole> _roleManager; 

        public UserDomainService(IRepositoryFactory<UserEntity> repositoryFactory, IUnitOfWork unitOfWork, RoleManager<IdentityRole> roleManager)
            : base(repositoryFactory, unitOfWork)
        {
            _roleManager = roleManager;
        }

        public async Task<UserSelfInfoReadModel> GetUserSelfInfoAsync(string userId)
        {
            return await ReadRepository.NoTrackedQuery.Where(u => u.Id == userId).AsReadModel(_roleManager,userId).SingleOrDefaultAsync();
        }

        public async Task<IPagedResult<UserReadModel>> GetUsersPageAsync(int pageNumber, int pageSize)
        {
            var qUsers = ReadRepository.NoTrackedQuery;
            var result = await qUsers.AsReadModel().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var usersNumber = await qUsers.CountAsync(u => u.IsActive);

            return new PagedResult<UserReadModel>
            {
                TotalPages = GetPagedResultTotalPages(usersNumber,pageSize),
                Content = result
            };
        }

        public async Task LockUserAsync(string userId)
        {
            var user = await ReadRepository.Query.SingleOrDefaultAsync(u => u.Id == userId);
            var lockableUser = (ILockable) user;

            lockableUser.Lock();
        }

        public async Task UnlockUserAsync(string userId)
        {
            var user = await ReadRepository.Query.SingleOrDefaultAsync(u => u.Id == userId);
            var lockableUser = (ILockable)user;

            lockableUser.Unlock();
        }

        public async Task DeleteUserAsync(string userId)
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
