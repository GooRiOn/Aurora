using Aurora.Domain.DomainServices.Interfaces;
using Aurora.Domain.Interfaces;
using Aurora.Infrastructure.Interfaces;
using Aurora.Services.Services.Interfaces;

namespace Aurora.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IDomainServiceFactory<IUserDomainService> _userDomainServiceFactory; 

        public UserService(IUnitOfWorkFactory unitOfWorkFactory, IDomainServiceFactory<IUserDomainService> userDomainServiceFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _userDomainServiceFactory = userDomainServiceFactory;
        }
    }
}
