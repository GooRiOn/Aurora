using System.Threading.Tasks;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Interfaces;
using Aurora.DomainProxy.Dtos;
using Aurora.DomainProxy.Mappings;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Interfaces;
using Microsoft.AspNet.Identity;

namespace Aurora.DomainProxy.Proxies
{
    public class UserAuthDomainServiceProxy : IUserAuthDomainServiceProxy
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IDomainServiceFactory<IUserAuthDomainService> _userAuthDomainServiceFactory; 

        public UserAuthDomainServiceProxy(IUnitOfWorkFactory unitOfWorkFactory, IDomainServiceFactory<IUserAuthDomainService> userAuthDomainServiceFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _userAuthDomainServiceFactory = userAuthDomainServiceFactory;
        }


        public async Task<IdentityResult> CreateUserAsync(UserCreateDto userCreateDto)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userAuthDoainService = _userAuthDomainServiceFactory.Get(unitOfWork);
                var userCreateDomainObject = userCreateDto.AsDomainObject();

                return await userAuthDoainService.CreateUserAsync(userCreateDomainObject);
            }
        }

        public async Task<SignInResult> PasswordSignInAsync(UserLoginDto userLoginModel)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userAuthDoainService = _userAuthDomainServiceFactory.Get(unitOfWork);
                var userLoginDomainObject = userLoginModel.AsDomainObject();

                return await userAuthDoainService.PasswordSignInAsync(userLoginDomainObject);
            }
        }

        public async Task SignOutAsync()
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userAuthDoainService = _userAuthDomainServiceFactory.Get(unitOfWork);
                await userAuthDoainService.SignOutAsync();
            };
        }

        public async Task<string> GetUserAuthToken(string userName)
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userAuthDoainService = _userAuthDomainServiceFactory.Get(unitOfWork);
                return await userAuthDoainService.GetUserAuthToken(userName);
            };
        }
    }
}
