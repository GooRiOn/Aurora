using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Aurora.Infrastructure.Models.ReadModels;

namespace Aurora.Infrastructure.Models.WriteModels
{
    public class ProjectCreateWriteModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public Guid MemberToken { get; set; }

        [Required]
        public IEnumerable<UserWriteModel> Members { get; set; }
    }
}
