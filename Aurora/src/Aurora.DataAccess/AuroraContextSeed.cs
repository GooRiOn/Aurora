using System;
using System.Threading.Tasks;
using Aurora.DataAccess.Identity;
using Aurora.Infrastructure.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Aurora.DataAccess
{
    public class AuroraContextSeed
    {
        public async Task Seed(AuroraContext context, UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager)
        {
            await context.Database.EnsureCreatedAsync();
            //*************SEED***************//

            await roleManager.CreateAsync(new IdentityRole { Name = RoleNames.Admin });

            var adminUser = await CreateUser(new UserEntity {UserName = "admin", Email = "admin@aurora.com"}, userManager);
            var adminRole = await roleManager.FindByNameAsync(RoleNames.Admin);

            context.UserRoles.Add(new IdentityUserRole<string> {UserId = adminUser.Id, RoleId = adminRole.Id});
            await context.SaveChangesAsync();
        }

        private async Task<UserEntity> CreateUser(UserEntity user, UserManager<UserEntity> userManager)
        {
            await userManager.CreateAsync(user, "test123");
            return user; 
        }
    }
}
