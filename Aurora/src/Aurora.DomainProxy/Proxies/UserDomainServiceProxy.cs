using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Interfaces;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;

namespace Aurora.DomainProxy.Proxies
{
    public class UserDomainServiceProxy : BaseProxy, IUserDomainServiceProxy
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IDomainServiceFactory<IUserDomainService> _userDomainServiceFactory; 

        public UserDomainServiceProxy(IUnitOfWorkFactory unitOfWorkFactory, IDomainServiceFactory<IUserDomainService> userDomainServiceFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _userDomainServiceFactory = userDomainServiceFactory;
        }

        public async Task<IPagedResult<UserReadModel>> GetUsersPageAsync(int pageNumber, int pageSize)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userDomainService = _userDomainServiceFactory.Get(unitOfWork);
                return await userDomainService.GetUsersPageAsync(pageNumber, pageSize);
            }
        }

        public async Task<IResult> LockUser(string userId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get(false))
            {
                var userDomainService = _userDomainServiceFactory.Get(unitOfWork);
                await userDomainService.LockUserAsync(userId);
                return await CreateResultAsync(unitOfWork);
            }
        }

        public async Task<IResult> UnlockUser(string userId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get(false))
            {
                var userDomainService = _userDomainServiceFactory.Get(unitOfWork);
                await userDomainService.UnlockUserAsync(userId);
                return await CreateResultAsync(unitOfWork);
            }
        }

        public async Task<IResult> DeleteUser(string userId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get(false))
            {
                var userDomainService = _userDomainServiceFactory.Get(unitOfWork);
                await userDomainService.DeleteUserAsync(userId);
                return await CreateResultAsync(unitOfWork);
            }
        }

        public async Task<IEnumerable<UserReadModel>> FindUsersByPhraseAsync(string searchPhrase)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userDomainService = _userDomainServiceFactory.Get(unitOfWork);
                return await userDomainService.FindUsersByPhraseAsync(searchPhrase);
            }
        }

        public async Task<byte[]> GetUserGravatarAsync(string userName)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userDomainService = _userDomainServiceFactory.Get(unitOfWork);
                return await userDomainService.GetUserGravatarAsync(userName);
            }
        }
    }
}