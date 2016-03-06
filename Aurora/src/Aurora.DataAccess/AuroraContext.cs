using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aurora.Infrastructure.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Aurora.DataAccess
{
    public class AuroraContext : IdentityDbContext<UserEntity>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=DESKTOP-JQOI1KG;database=Aurora;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<InternalEntity>().Property<DateTime>("CreatedDate");
            builder.Entity<InternalEntity>().Property<DateTime>("UpdatedDate");
            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();

            var modifiedEntities = ChangeTracker.Entries<InternalEntity>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

            foreach (var entity in modifiedEntities)
            {
                if (entity.State == EntityState.Added)
                    entity.Property("CreatedDate").CurrentValue = DateTime.UtcNow;

                entity.Property("UpdatedDate").CurrentValue = DateTime.UtcNow;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
