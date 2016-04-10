using System;

namespace Aurora.DataAccess.Entities.Interfaces
{
    public interface IInternalEntity
    {
        
    }

    public interface IInternalEntity<TKey> : IInternalEntity
    {
        TKey Id { get; set; }
    }
}
