using Aurora.Infrastructure.Entities.Interfaces;

namespace Aurora.Infrastructure.Entities
{
    public abstract class KeyedInternalEntity<TKey> : InternalEntity,IKeyedInternalEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
