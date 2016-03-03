using Aurora.Infrastructure.Entities.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Aurora.Infrastructure.Entities
{
    public class UserEntity : IdentityUser, IInternalEntity<string>, ISoftDeletable, ILockable
    {
        public bool IsActive { get; private set; }
        
        public bool IsLocked { get; private set; }

        public void Lock()
        {
            this.IsLocked = true;
        }

        public void Delete()
        {
            this.IsActive = false;
        }

    }
}
