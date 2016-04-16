using System;

namespace Aurora.Infrastructure.Models.ReadModels
{
    public class SprintReadModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime EstimatedStartDate { get; set; }

        public DateTime EstimatedEndDate { get; set; }
    }
}
