using System.Threading.Tasks;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.DomainProxy.Proxies.Interfaces
{
    public interface IBaseProxy
    {
        Task<IResult> CreateResultAsync(IUnitOfWork unitOfWork);
        Task<IResult<TContent>> CreateContentResultAsync<TContent>(IUnitOfWork unitOfWork, TContent content);
        Task<IPagedResult<TContent>> CreatePagedResultAsync<TContent>(IUnitOfWork unitOfWork, TContent content,int totalPages);
    }
}