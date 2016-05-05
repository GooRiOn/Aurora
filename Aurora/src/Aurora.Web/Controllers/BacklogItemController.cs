using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aurora.DomainProxy.Proxies.Interfaces;
using Microsoft.AspNet.Mvc;

namespace Aurora.Web.Controllers
{
    [Route("api/Backlog")]
    public class BacklogItemController: BaseController
    {
        private readonly IBacklogItemDomainServiceProxy _backlogItemDomainServiceProxy;

        public BacklogItemController(IBacklogItemDomainServiceProxy backlogItemDomainServiceProxy)
        {
            _backlogItemDomainServiceProxy = backlogItemDomainServiceProxy;
        }
    }
}
