using System.Threading.Tasks;
using Aurora.DomainProxy.Dtos;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data.Interfaces;
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

        [HttpPost("Create")]
        public async Task<IResult> CreateProjectAsync([FromBody] ProjectCreateDto project)
        {
            return  await _projectDomainServiceProxy.CreateProjectAsync(project);
        }
    }
}
