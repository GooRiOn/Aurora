using System;
using System.ComponentModel.DataAnnotations;
using Aurora.Infrastructure.Entities.Interfaces;

namespace Aurora.Infrastructure.Entities
{
    public abstract class InternalEntity : IInternalEntity<int>, ISoftDeletable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsActive { get; private set; }

        public InternalEntity()
        {
            this.IsActive = true;
        }

        void ISoftDeletable.Delete()
        {
            this.IsActive = false;
        }
    }
}
