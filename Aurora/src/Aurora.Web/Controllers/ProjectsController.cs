using Aurora.DomainProxy.Proxies.Interfaces;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Aurora.Web.Controllers
{
    [Route("api/Projects"), Authorize("User")]
    public class ProjectsController : BaseController
    {
        private readonly IProjectDomainServiceProxy _projectDomainServiceProxy;

        public ProjectsController(IProjectDomainServiceProxy projectDomainServiceProxy)
        {
            _projectDomainServiceProxy = projectDomainServiceProxy;
        }
    }
}
