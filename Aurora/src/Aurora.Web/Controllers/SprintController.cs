using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;
using Aurora.Infrastructure.Models.WriteModels;
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

        [HttpGet("")]
        public async Task<IEnumerable<SprintReadModel>> GetProjectSprintsAsync(int projectId)
        {
            return await _sprintDomainServiceProxy.GetProjectSprintsAsync(projectId);
        }

        [HttpPost("Create")]
        public async Task<IResult> CreateSprintAsync([FromBody] SprintWriteModel sprint)
        {
            return await _sprintDomainServiceProxy.CreateSprintAsync(sprint);
        }

        [HttpPost("Update")]
        public async Task<IResult> UpdateSprintAsync([FromBody] SprintWriteModel sprint)
        {
            return await _sprintDomainServiceProxy.UpdateSprintAsync(sprint);
        }

        [HttpPost("{sprintId}/Delete")]
        public async Task<IResult> UpdateSprintAsync(int sprintId)
        {
            return await _sprintDomainServiceProxy.DeleteSprintAsync(sprintId);
        }
    }
}
