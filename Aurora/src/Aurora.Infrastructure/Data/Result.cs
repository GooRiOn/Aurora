using System.Collections.Generic;
using Aurora.Infrastructure.Data.Interfaces;

namespace Aurora.Infrastructure.Data
{
    public class Result : IResult
    {
         public string[] Errors { get; set; }
         public ResultStateEnum State { get; set; }

         public Result()
         {
             State = ResultStateEnum.Succeed;
         }
    }
    public class PagedResult<TContent> : IPagedResult<TContent>
    {
        public IEnumerable<TContent> Content { get; set; }
        public int TotalPages { get; set; }
    }

}