using System.ComponentModel.DataAnnotations.Schema;
using Aurora.DataAccess.Entities.Interfaces;

namespace Aurora.DataAccess.Entities
{
    public class TaskLabelEntity : IInternalEntity
    {
        public int LabelId { get; set; }

        [ForeignKey("LabelId")]
        public LabelEntity Label {get; set; }
        
        public int TaskId { get; set; }

        [ForeignKey("TaskId")]
        public TaskEntity Task { get; set; }
    }
}
