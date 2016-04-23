using System;
using System.Collections.Generic;
using Aurora.Infrastructure.Enums;

namespace Aurora.Infrastructure.Models.ReadModels
{
    public class SprintReadModel
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string Name { get; set; }

        public DateTime EstimatedStartDate { get; set; }

        public DateTime EstimatedEndDate { get; set; }

        public SprintState State { get; set; }
    }
}
