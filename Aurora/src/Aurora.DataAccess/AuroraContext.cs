using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aurora.DataAccess.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace Aurora.DataAccess
{
    public class AuroraContext : IdentityDbContext<UserEntity>
    {
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<SprintEntity> Sprints { get; set; } 
        public DbSet<BacklogItemEntity> BacklogItems { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<LabelEntity> Labels { get; set; }  
        public DbSet<StageEntity> Stages { get; set; } 
         
             
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=DESKTOP-JQOI1KG;database=Aurora;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserProjectEntity>().HasKey(up => new { up.ProjectId, up.UserId});
            builder.Entity<TaskLabelEntity>().HasKey(tl => new { tl.TaskId, tl.LabelId });

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

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
