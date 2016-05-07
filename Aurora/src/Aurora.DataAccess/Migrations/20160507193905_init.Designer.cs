using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Aurora.DataAccess;

namespace Aurora.DataAccess.Migrations
{
    [DbContext(typeof(AuroraContext))]
    [Migration("20160507193905_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aurora.DataAccess.Entities.BacklogItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<int>("SprintId");

                    b.Property<int>("State");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Aurora.DataAccess.Entities.LabelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<int>("ProjectId");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Aurora.DataAccess.Entities.ProjectEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<Guid>("MemberToken");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Aurora.DataAccess.Entities.SprintEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("EstimatedEndDate");

                    b.Property<DateTime>("EstimatedStartDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<int>("ProjectId");

                    b.Property<int>("State");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Aurora.DataAccess.Entities.TaskEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BacklogItemId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Tite");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<int>("UserProjectId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Aurora.DataAccess.Entities.TaskLabelEntity", b =>
                {
                    b.Property<int>("TaskId");

                    b.Property<int>("LabelId");

                    b.HasKey("TaskId", "LabelId");
                });

            modelBuilder.Entity("Aurora.DataAccess.Entities.UserEntity", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<byte[]>("Gravatar");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsLocked");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:Schema", "usr");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("Aurora.DataAccess.Entities.UserProjectEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActivated");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeafult");

                    b.Property<int>("ProjectId");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("Aurora.DataAccess.Entities.BacklogItemEntity", b =>
                {
                    b.HasOne("Aurora.DataAccess.Entities.SprintEntity")
                        .WithMany()
                        .HasForeignKey("SprintId");
                });

            modelBuilder.Entity("Aurora.DataAccess.Entities.LabelEntity", b =>
                {
                    b.HasOne("Aurora.DataAccess.Entities.ProjectEntity")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Aurora.DataAccess.Entities.SprintEntity", b =>
                {
                    b.HasOne("Aurora.DataAccess.Entities.ProjectEntity")
                        .WithMany()
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Aurora.DataAccess.Entities.TaskEntity", b =>
                {
                    b.HasOne("Aurora.DataAccess.Entities.BacklogItemEntity")
                        .WithMany()
                        .HasForeignKey("BacklogItemId");

                    b.HasOne("Aurora.DataAccess.Entities.UserProjectEntity")
                        .WithMany()
                        .HasForeignKey("UserProjectId");
                });

            modelBuilder.Entity("Aurora.DataAccess.Entities.TaskLabelEntity", b =>
                {
                    b.HasOne("Aurora.DataAccess.Entities.LabelEntity")
                        .WithMany()
                        .HasForeignKey("LabelId");

                    b.HasOne("Aurora.DataAccess.Entities.TaskEntity")
                        .WithMany()
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("Aurora.DataAccess.Entities.UserProjectEntity", b =>
                {
                    b.HasOne("Aurora.DataAccess.Entities.ProjectEntity")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("Aurora.DataAccess.Entities.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Aurora.DataAccess.Entities.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Aurora.DataAccess.Entities.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Aurora.DataAccess.Entities.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
