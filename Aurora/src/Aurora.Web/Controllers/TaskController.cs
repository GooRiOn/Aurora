using Aurora.DomainProxy.Proxies.Interfaces;
using Microsoft.AspNet.Mvc;

namespace Aurora.Web.Controllers
{
    [Route("api/Tasks")]
    public class TaskController : BaseController
    {
        private readonly ITaskDomainServiceProxy _taskDomainServiceProxy;

        public TaskController(ITaskDomainServiceProxy taskDomainServiceProxy)
        {
            _taskDomainServiceProxy = taskDomainServiceProxy;
        }
    }
}
