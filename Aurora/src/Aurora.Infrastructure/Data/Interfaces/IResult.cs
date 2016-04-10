using System.Collections.Generic;

namespace Aurora.Infrastructure.Data.Interfaces
{
    public interface IResult
    {
        IEnumerable<string> Errors { get; set; }
        ResultStateEnum State { get; set; }
    }
    
    public interface IPagedResult<TContent>
    {
        IEnumerable<TContent> Content { get; set; }
        int TotalPages { get; set; }
    }
}