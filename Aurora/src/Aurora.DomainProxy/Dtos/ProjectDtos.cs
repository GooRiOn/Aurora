using System.Collections.Generic;

namespace Aurora.DomainProxy.Dtos
{
    public class ProjectCreateDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<UserDto> Members { get; set; } 
    }
}
