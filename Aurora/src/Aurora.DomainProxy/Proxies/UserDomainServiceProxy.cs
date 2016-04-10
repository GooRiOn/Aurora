using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Interfaces;
using Aurora.DomainProxy.Dtos;
using Aurora.DomainProxy.Mappings;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Interfaces;

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

        public async Task<IPagedResult<UserDto>> GetUsersPageAsync(int pageNumber, int pageSize)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userDomainService = _userDomainServiceFactory.Get(unitOfWork);
                var pagedResult = await userDomainService.GetUsersPageAsync(pageNumber, pageSize);

                var dtos = pagedResult.Content.Select(c => c.AsDto());
                return GetPagedResult(dtos, pagedResult.TotalPages);
            }
        }

        public async Task<IResult> LockUser(string userId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get(false))
            {
                var userDomainService = _userDomainServiceFactory.Get(unitOfWork);
                await userDomainService.LockUser(userId);
                return await CreateResultAsync(unitOfWork);
            }
        }

        public async Task<IResult> UnlockUser(string userId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get(false))
            {
                var userDomainService = _userDomainServiceFactory.Get(unitOfWork);
                await userDomainService.UnlockUser(userId);
                return await CreateResultAsync(unitOfWork);
            }
        }

        public async Task<IResult> DeleteUser(string userId)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get(false))
            {
                var userDomainService = _userDomainServiceFactory.Get(unitOfWork);
                await userDomainService.DeleteUser(userId);
                return await CreateResultAsync(unitOfWork);
            }
        }

        public async Task<IEnumerable<UserDto>> FindUsersByPhraseAsync(string searchPhrase)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userDomainService = _userDomainServiceFactory.Get(unitOfWork);
                var result = await userDomainService.FindUsersByPhraseAsync(searchPhrase);
                return result.Select(u => u.AsDto());
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