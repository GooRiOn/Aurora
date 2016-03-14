using System;

namespace Aurora.DataAccess.Entities.Interfaces
{
    public interface IInternalEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
