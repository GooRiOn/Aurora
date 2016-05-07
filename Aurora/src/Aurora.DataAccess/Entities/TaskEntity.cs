using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aurora.DataAccess.Entities
{
    public class TaskEntity : InternalEntity
    {
        public TaskEntity()
        {
            this.Labels = new HashSet<TaskLabelEntity>();
        }

        public int BacklogItemId { get; set; }

        [ForeignKey("BacklogItemId")]
        public BacklogItemEntity BacklogItem { get; set; }
       
        public int UserProjectId { get; set; }

        [ForeignKey("UserProjectId")]
        public UserProjectEntity UserProject { get; set; }

        public string Tite { get; set; }

        public string Description { get; set; }

        public ICollection<TaskLabelEntity> Labels { get; set; } 
    }
}
