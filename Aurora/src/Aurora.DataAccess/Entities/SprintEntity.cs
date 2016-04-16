using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aurora.DataAccess.Entities
{
    public class SprintEntity : InternalEntity
    {
        public SprintEntity()
        {
            this.BacklogItems = new HashSet<BacklogItemEntity>();
        }
        
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public ProjectEntity Project { get; set; }

        public int SprintNumber { get; set; }

        public DateTime EstimatedStartDate { get; set; }

        public DateTime EstimatedEndDate { get; set; }

        public ICollection<BacklogItemEntity> BacklogItems { get; set; } 
    }
}
