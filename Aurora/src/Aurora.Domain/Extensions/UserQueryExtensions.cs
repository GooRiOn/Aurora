using System.Linq;
using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Models.ReadModels;


namespace Aurora.Domain.Extensions
{
    public static class UserQueryExtensions
    {
        public static IQueryable<UserReadModel> AsReadModel(this IQueryable<UserEntity> that)
        {
            return that.Where(u => u.IsActive).Select(u => new UserReadModel
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
