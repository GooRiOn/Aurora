using System;
using System.ComponentModel.DataAnnotations.Schema;
using Aurora.DataAccess.Entities.Interfaces;

namespace Aurora.DataAccess.Entities
{
    public class UserProjectEntity : IInternalEntity
    {
        public string UserId { get; set; }
        
        [ForeignKey("UserId")]
        public UserEntity User { get; set; } 

        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public ProjectEntity Project { get; set; }

        public bool IsDeafult { get; set; }

        public bool IsVeryfied { get; set; }
    }
}
