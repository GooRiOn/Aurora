namespace Aurora.Infrastructure.Data.Interfaces
{
    public interface IResult
    {
        string[] Errors { get; set; }
        ResultStateEnum State { get; set; }
    }

    public interface IResult<TContent> : IResult
    {
        TContent Content { get; set; }
    }

    public interface IPagedResult<TContent> : IResult<TContent>
    {
        int TotalPages { get; set; }
    }
}