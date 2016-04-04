using System;

namespace Aurora.DataAccess.Entities
{
    public class SprintEntity : InternalEntity
    {
        public int SprintNumber { get; set; }

        public DateTime EstimatedStartDate { get; set; }

        public DateTime EstimatedEndDate { get; set; }
    }
}
