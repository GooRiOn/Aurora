using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aurora.DataAccess.Entities
{
    public class LabelEntity : InternalEntity
    {
        public LabelEntity()
        {
            this.Tasks = new HashSet<TaskLabelEntity>();
        }

        public string Name { get; set; }

        public string Color { get; set; }

        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public ProjectEntity Project { get; set; }

        public ICollection<TaskLabelEntity> Tasks { get; set; } 
    }
}
