using System;
using System.ComponentModel.DataAnnotations.Schema;
using Aurora.DataAccess.Entities.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Aurora.DataAccess.Entities
{
    [Table("Users",Schema = "usr")]
    public class UserEntity : IdentityUser, IInternalEntity<string>, ISoftDeletable, ILockable
    {
        public UserEntity()
        {
            this.IsActive = true;
            this.IsLocked = false;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

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
