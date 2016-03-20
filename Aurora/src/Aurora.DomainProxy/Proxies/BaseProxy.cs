using System;
using System.Threading.Tasks;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Interfaces;

namespace Aurora.DomainProxy.Proxies
{
    public abstract class BaseProxy : IBaseProxy
    {
        public async Task<IResult> CreateResultAsync(IUnitOfWork unitOfWork)
        {
            var result = new Result();

            await CommitAsync(unitOfWork, result);

            return result;
        }

        public async Task<IResult<TContent>> CreateContentResultAsync<TContent>(IUnitOfWork unitOfWork, TContent content)
        {
            var result = new Result<TContent>
            {
                Content = content
            };

            await CommitAsync(unitOfWork, result);

            return result;
        }

        public async Task<IPagedResult<TContent>> CreatePagedResultAsync<TContent>(IUnitOfWork unitOfWork, TContent content, int totalPages)
        {
            var result = new PagedResult<TContent>
            {
                Content = content,
                TotalPages = totalPages
            };

            await CommitAsync(unitOfWork, result);

            return result;
        }

        private static async Task CommitAsync(IUnitOfWork unitOfWork, Result result)
        {
            try
            {
                await unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                result.Errors = new[] {"An error has occured during SaveChanges"};
                result.State = ResultStateEnum.Failed;
            }
        }
    }
}
