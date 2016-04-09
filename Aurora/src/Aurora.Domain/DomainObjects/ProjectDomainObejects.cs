using System.Collections.Generic;

namespace Aurora.Domain.DomainObjects
{
    public class ProjectCreateDomainObject
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<UserDomainObject> Members { get; set; } 
    }
}
