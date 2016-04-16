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

        public int StageId { get; set; }

        [ForeignKey("StageId")]
        public StageEntity Stage { get; set; }

        public string MemberId { get; set; }

        [ForeignKey("MemberId")]
        public UserProjectEntity Member { get; set; }

        public string Tite { get; set; }

        public string Description { get; set; }

        public ICollection<TaskLabelEntity> Labels { get; set; } 
    }
}
