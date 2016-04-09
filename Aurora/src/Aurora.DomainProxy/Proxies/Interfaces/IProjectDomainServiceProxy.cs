using System.Threading.Tasks;
using Aurora.DomainProxy.Dtos;
using Aurora.Infrastructure.Data.Interfaces;

namespace Aurora.DomainProxy.Proxies.Interfaces
{
    public interface IProjectDomainServiceProxy : IBaseProxy
    {
        Task<IResult> CreateProjectAsync(ProjectCreateDto project);
    }
}