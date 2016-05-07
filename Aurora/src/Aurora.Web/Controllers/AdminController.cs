using System.Linq;
using System.Threading.Tasks;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Aurora.Web.Controllers
{
    [Route("api/Admin"), Authorize("Admin")]
    public class AdminController : BaseController
    {
        private readonly IUserDomainServiceProxy _userDomainServiceProxy;
        private readonly IUserAuthDomainServiceProxy _userAuthDomainServiceProxy;

        public AdminController(IUserDomainServiceProxy userDomainServiceProxy, IUserAuthDomainServiceProxy userAuthDomainServiceProxy)
        {
            _userDomainServiceProxy = userDomainServiceProxy;
            _userAuthDomainServiceProxy = userAuthDomainServiceProxy;
        }

        [HttpGet("Users/{pageNumber}/Page/{pageSize}/Size")]
        public async Task<IPagedResult<UserReadModel>> GetUsersPageAsync(int pageNumber, int pageSize)
        {
            return await _userDomainServiceProxy.GetUsersPageAsync(pageNumber, pageSize);
        }

        [HttpPost("Users/{userId}/Lock")]
        public async Task<IResult> LockUserAsync(string userId)
        {
            return await _userDomainServiceProxy.LockUserAsync(userId);
        }

        [HttpPost("Users/{userId}/Unlock")]
        public async Task<IResult> UnlockUserAsync(string userId)
        {
            return await _userDomainServiceProxy.UnlockUserAsync(userId);
        }

        [HttpPost("Users/{userId}/Delete")]
        public async Task<IResult> DeleteUserAsync(string userId)
        {
            return await _userDomainServiceProxy.DeleteUserAsync(userId);
        }

        [HttpPost("Users/{userId}/Password/{newPassword}/Reset")]
        public async Task<IResult> ResetUserPaswordAsync(string userId, string newPassword)
        {
            return await _userAuthDomainServiceProxy.ResetUserPasswordAsync(userId,newPassword);
        }
    }
}
