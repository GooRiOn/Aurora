using System.Linq;
using Aurora.DataAccess.Entities;
using Aurora.Domain.DomainObjects;

namespace Aurora.Domain.Extensions
{
    public static class UserQueryExtensions
    {
        public static IQueryable<UserDomainObject> AsDomainObject(this IQueryable<UserEntity> that)
        {
            return that.Where(u => u.IsActive).Select(u => new UserDomainObject
            {
                Id = u.Id,
                UserName = u.UserName,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                IsLocked = u.IsLocked
            });
        }
    }
}
