using Aurora.Infrastructure.Entities.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Aurora.Infrastructure.Entities
{
    public class UserEntity : IdentityUser, IKeyedInternalEntity<string>, ISoftDeletable, ILockable
    {
        public bool IsActive { get; private set; }
        
        public bool IsLocked { get; private set; }

        void ILockable.Lock()
        {
            this.IsLocked = true;
        }

        void ILockable.Unlock()
        {
            this.IsLocked = false;
        }

        void ISoftDeletable.Delete()
        {
            this.IsActive = false;
        }

    }
}
