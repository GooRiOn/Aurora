using System;

namespace Aurora.Infrastructure.Entities.Interfaces
{
    public interface IAuditable
    {
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}