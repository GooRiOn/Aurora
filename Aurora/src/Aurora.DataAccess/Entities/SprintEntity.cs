﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Aurora.Infrastructure.Enums;

namespace Aurora.DataAccess.Entities
{
    public class SprintEntity : InternalEntity
    {
        public SprintEntity()
        {
            this.BacklogItems = new HashSet<BacklogItemEntity>();
        }
        
        public string Name { get; set; }

        public DateTime EstimatedStartDate { get; set; }

        public DateTime EstimatedEndDate { get; set; }

        public SprintState State { get; set; }

        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public ProjectEntity Project { get; set; }

        public ICollection<BacklogItemEntity> BacklogItems { get; set; } 
    }
}
