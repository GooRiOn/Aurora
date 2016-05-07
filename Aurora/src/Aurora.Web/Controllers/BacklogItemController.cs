using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Models.ReadModels;
using Aurora.Infrastructure.Models.WriteModels;
using Microsoft.AspNet.Mvc;

namespace Aurora.Web.Controllers
{
    [Route("api/Backlogs")]
    public class BacklogItemController: BaseController
    {
        private readonly IBacklogItemDomainServiceProxy _backlogItemDomainServiceProxy;

        public BacklogItemController(IBacklogItemDomainServiceProxy backlogItemDomainServiceProxy)
        {
            _backlogItemDomainServiceProxy = backlogItemDomainServiceProxy;
        }

        [HttpGet("{projectId}")]
        public async Task<IEnumerable<BacklogItemReadModel>> GetProjectBacklogItemsAsync(int projectId)
        {
            return await _backlogItemDomainServiceProxy.GetProjectBacklogItemsAsync(projectId);
        }

        [HttpPost("Add")]
        public async Task<IResult> AddBacklogItemAsync([FromBody] BacklogItemWriteModel backlogItem)
        {
            return await _backlogItemDomainServiceProxy.AddBacklogItemAsync(backlogItem);
        }

        [HttpPost("Update")]
        public async Task<IResult> UdateBacklogItemAsync([FromBody] BacklogItemWriteModel backlogItem)
        {
            return await _backlogItemDomainServiceProxy.UpdateBacklogItem(backlogItem);
        }

        [HttpPost("{backlogItemId/Delete}")]
        public async Task<IResult> AddBacklogItemAsync(int backlogItemId)
        {
            return await _backlogItemDomainServiceProxy.DeleteBacklogItemAsync(backlogItemId);
        }
    }
}
