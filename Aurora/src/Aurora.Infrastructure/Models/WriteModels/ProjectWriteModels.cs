using System;
using System.Collections.Generic;
using Aurora.Infrastructure.Models.ReadModels;

namespace Aurora.Infrastructure.Models.WriteModels
{
    public class ProjectCreateWriteModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid MemberToken { get; set; }

        public IEnumerable<UserWriteModel> Members { get; set; }
    }
}
