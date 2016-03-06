namespace Aurora.Infrastructure.Entities.Interfaces
{
    public interface IInternalEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
