using AppVersionControlApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Version = AppVersionControlApi.Entities.Version;

namespace AppVersionControlApi.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Version> Versions { get; set; }

        public DbSet<UserApplication> UserApplications{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Name= "user",
                    NormalizedName = "User"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
            builder.Entity<Admin>().ToTable("Admins");
            builder.Entity<User>().ToTable("Users");

            builder.Entity<Application>()
               .HasMany(a => a.Versions)
               .WithOne(v => v.Application)
               .HasForeignKey(v => v.ApplicationId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Application>()
                .HasOne<Version>()
                .WithMany()
                .HasForeignKey(a => a.CurrentVersionId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<UserApplication>().HasKey(x => new { x.ApplicationId, x.UserId });

        }


    }
}
