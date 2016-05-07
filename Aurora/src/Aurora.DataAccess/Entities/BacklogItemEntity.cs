using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Aurora.Infrastructure.Enums;

namespace Aurora.DataAccess.Entities
{
    public class BacklogItemEntity : InternalEntity
    {
        public BacklogItemEntity()
        {
            this.Tasks = new HashSet<TaskEntity>();
        }

        public int SprintId { get; set; }

        [ForeignKey("SprintId")]
        public SprintEntity Sprint { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
       
        public BacklogItemState State { get; set; }

        public ICollection<TaskEntity> Tasks { get; set; } 
    }
}
