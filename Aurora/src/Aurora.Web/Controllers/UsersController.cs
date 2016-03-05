using System.Threading.Tasks;
using Aurora.Domain.Interfaces;
using Aurora.Domain.Services.Interfaces;
using Aurora.Infrastructure.Interfaces;
using Microsoft.AspNet.Mvc;

namespace Aurora.Web.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IServiceFactory<IUserService> _userServiceFactory;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UsersController(IServiceFactory<IUserService> userServiceFactory, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _userServiceFactory = userServiceFactory;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        [HttpGet("test")]
        public async Task Test()
        {
            using (var unitOfWork = _unitOfWorkFactory.Get())
            {
                var userService = _userServiceFactory.Get(unitOfWork);
            }
        }
    }
}
