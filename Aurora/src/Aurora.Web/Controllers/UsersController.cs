using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Aurora.Web.Controllers
{
    [Route("api/Users")]
    public class UsersController : BaseController
    {
        private readonly IUserDomainServiceProxy _userDomainServiceProxy;

        public UsersController(IUserDomainServiceProxy userDomainServiceProxy)
        {
            _userDomainServiceProxy = userDomainServiceProxy;
        }

        [HttpGet("{searchPhrase}/Find")]
        public async Task<IEnumerable<UserReadModel>> FindUsersBySearchPhraseAsync(string searchPhrase)
        {
            return await _userDomainServiceProxy.FindUsersByPhraseAsync(searchPhrase);
        }

        [HttpGet("{userName}/Gravatar"), AllowAnonymous]
        public async Task<FileResult> GetUserGravatarAsync(string userName)
        {
            var gravatar = await _userDomainServiceProxy.GetUserGravatarAsync(userName);

            return new FileContentResult(gravatar, "image/jpeg");
        }
    }
}
