using Aurora.DomainProxy.Proxies.Interfaces;
using Microsoft.AspNet.Mvc;

namespace Aurora.Web.Controllers
{
    [Route("api/Sprints")]
    public class SprintController : BaseController
    {
        private readonly ISprintDomainServiceProxy _sprintDomainServiceProxy;

        public SprintController(ISprintDomainServiceProxy sprintDomainServiceProxy)
        {
            _sprintDomainServiceProxy = sprintDomainServiceProxy;
        }
    }
}
