using System.Linq;
using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Models.ReadModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


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

        public static IQueryable<UserSelfInfoReadModel> AsReadModel(this IQueryable<UserEntity> that, RoleManager<IdentityRole> roleManager, string userId)
        {
            return that.Select(u => new UserSelfInfoReadModel
            {
                UserName = u.UserName,
                Projects = u.Projects.Where(p => p.IsActive && p.IsActivated).Select(p => new ProjectReadModel
                {
                    Id = p.ProjectId,
                    Name = p.Project.Name,
                    IsDefault = p.IsDeafult
                }),
                Roles = roleManager.Roles.Where(r => r.Users.Any(ur => ur.UserId == userId)).Select(r => r.Name).ToList()
            });
        } 
    }
}
