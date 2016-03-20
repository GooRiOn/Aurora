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

    public class Result<TContent> : Result, IResult<TContent>
    {
         public TContent Content { get; set; }
    }

    public class PagedResult<TContent> : Result<TContent>, IPagedResult<TContent>
    {
         public int TotalPages { get; set; }
    }

}