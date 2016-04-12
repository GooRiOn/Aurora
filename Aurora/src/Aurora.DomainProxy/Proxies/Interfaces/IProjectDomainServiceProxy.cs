using System;
using System.Threading.Tasks;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Models.WriteModels;

namespace Aurora.DomainProxy.Proxies.Interfaces
{
    public interface IProjectDomainServiceProxy : IBaseProxy
    {
        Task<IResult> CreateProjectAsync(ProjectCreateWriteModel project);
        Task<IResult> ActivateProjectMemberAsync(Guid memberToken, string userId);
    }
}