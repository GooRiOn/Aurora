﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aurora.DataAccess.Entities
{
    public class UserProjectEntity : InternalEntity
    {
        public UserProjectEntity()
        {
            this.Tasks = new HashSet<TaskEntity>();
        }

        public string UserId { get; set; }
        
        [ForeignKey("UserId")]
        public UserEntity User { get; set; } 

        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public ProjectEntity Project { get; set; }

        public bool IsDeafult { get; set; }

        public bool IsActivated { get; set; }

        public ICollection<TaskEntity> Tasks { get; set; } 
    }
}
