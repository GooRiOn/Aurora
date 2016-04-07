using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.DomainProxy.Dtos;
using Aurora.DomainProxy.Proxies.Interfaces;
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
        public async Task<IEnumerable<UserDto>> FindUsersBySearchPhraseAsync(string searchPhrase)
        {
            return await _userDomainServiceProxy.FindUsersByPhraseAsync(searchPhrase);
        }
    }
}
