using Aurora.DomainProxy.Proxies.Interfaces;
using Microsoft.AspNet.Mvc;

namespace Aurora.Web.Controllers
{
    [Route("api/Projects")]
    public class ProjectsController : BaseController
    {
        private readonly IProjectDomainServiceProxy _projectDomainServiceProxy;

        public ProjectsController(IProjectDomainServiceProxy projectDomainServiceProxy)
        {
            _projectDomainServiceProxy = projectDomainServiceProxy;
        }
    }
}
