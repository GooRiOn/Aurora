using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.DomainProxy.Proxies.Interfaces
{
    public interface IBaseProxy
    {
        Task<IResult> CreateResultAsync(IUnitOfWork unitOfWork);
        IPagedResult<TResult> GetPagedResult<TResult>(IEnumerable<TResult> source, int totalPagesNumber);
    }
}