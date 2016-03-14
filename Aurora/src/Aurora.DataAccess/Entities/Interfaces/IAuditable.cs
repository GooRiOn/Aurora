using System;

namespace Aurora.DataAccess.Entities.Interfaces
{
    public interface IAuditable
    {
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}