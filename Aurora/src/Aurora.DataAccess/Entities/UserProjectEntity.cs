using System.ComponentModel.DataAnnotations.Schema;

namespace Aurora.DataAccess.Entities
{
    public class UserProjectEntity
    {
        public string UserId { get; set; }
        
        [ForeignKey("UserId")]
        public UserEntity User { get; set; } 

        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public ProjectEntity Project { get; set; }

        public bool IsDeafult { get; set; }
    }
}
