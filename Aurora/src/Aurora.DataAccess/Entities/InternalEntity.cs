using System;
using System.ComponentModel.DataAnnotations;
using Aurora.DataAccess.Entities.Interfaces;

namespace Aurora.DataAccess.Entities
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
