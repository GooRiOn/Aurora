namespace Aurora.Infrastructure.Entities.Interfaces
{
    public interface IKeyedInternalEntity<TKey> : IInternalEntity
    {
        TKey Id { get; set; }
    }
}
