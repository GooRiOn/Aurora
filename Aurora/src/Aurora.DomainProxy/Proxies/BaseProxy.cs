using System;
using System.Collections.Generic;
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

            try
            {
                await unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                unitOfWork.Rollback();
                result.Errors = new[] { "An error has occured during SaveChanges" };
                result.State = ResultStateEnum.Failed;
            }

            return result;
        }
    }
}

