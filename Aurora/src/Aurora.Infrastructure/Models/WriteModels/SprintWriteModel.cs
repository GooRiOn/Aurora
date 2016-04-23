using System;
using Aurora.Infrastructure.Enums;

namespace Aurora.Infrastructure.Models.WriteModels
{
    public class SprintWriteModel
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string Name { get; set; }

        public DateTime EstimatedStartDate { get; set; }

        public DateTime EstimatedEndDate { get; set; }

        public SprintState State { get; set; }
    }
}
