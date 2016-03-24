using System.Threading.Tasks;
using Aurora.DataAccess;
using Aurora.DataAccess.Entities;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Interfaces;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.DomainProxy.Proxies
{
    public class UserDomainServiceProxy : IUserDomainServiceProxy
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IDomainServiceFactory<IUserDomainService> _userDomainServiceFactory; 

        public UserDomainServiceProxy(IUnitOfWorkFactory unitOfWorkFactory, IDomainServiceFactory<IUserDomainService> userDomainServiceFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _userDomainServiceFactory = userDomainServiceFactory;
        }

        public async Task<int> AddUser()
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userDomainService = _userDomainServiceFactory.Get(unitOfWork);

                userDomainService.Add(new UserEntity());
                return await unitOfWork.CommitAsync();
            }
        }
    }
}