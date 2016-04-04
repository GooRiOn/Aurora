using System.Collections.Generic;

namespace Aurora.DataAccess.Entities
{
    public class ProjectEntity : InternalEntity
    {
        public ProjectEntity()
        {
            this.ProjectMembers = new HashSet<UserProjectEntity>();
            this.Sprints = new HashSet<SprintEntity>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<UserProjectEntity> ProjectMembers { get; set; } 

        public ICollection<SprintEntity> Sprints { get; set; } 
    }
}
