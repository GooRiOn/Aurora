using System;
using System.Linq;
using System.Threading.Tasks;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Models.WriteModels;
using Aurora.Web.Services.Interfaces;
using Microsoft.AspNet.Mvc;

namespace Aurora.Web.Controllers
{
    [Route("api/Projects")]
    public class ProjectsController : BaseController
    {
        private readonly IProjectDomainServiceProxy _projectDomainServiceProxy;
        private readonly IEmailService _emailService;

        public ProjectsController(IProjectDomainServiceProxy projectDomainServiceProxy, IEmailService emailService)
        {
            _projectDomainServiceProxy = projectDomainServiceProxy;
            _emailService = emailService;
        }

        [HttpPost("Create")]
        public async Task<IResult> CreateProjectAsync([FromBody] ProjectCreateWriteModel project)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage).ToArray();
                return CreateResult(ResultStateEnum.Failed,errors);
            }

            project.MemberToken = Guid.NewGuid();

            var userId = GetUserId();
            var result = await _projectDomainServiceProxy.CreateProjectAsync(project, userId);

            if (result.State == ResultStateEnum.Failed)
                return result;

            var tasks = project.Members.Select(member => _emailService.SendProjectJoinEmail(project.Name, project.MemberToken, member.Email)).ToArray();

            Task.WaitAll(tasks);

            return result;
        }

        [HttpPost("{memberToken}/Join")]
        public async Task<IResult> JoinProjectAsync(Guid memberToken)
        {
            var userId = GetUserId();
            return await _projectDomainServiceProxy.ActivateProjectMemberAsync(memberToken, userId);
        }
    }
}
