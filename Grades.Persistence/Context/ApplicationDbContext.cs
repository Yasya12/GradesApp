using Grades.Domain.Entities;
using Grades.Domain.Entities.Utility;
using Grades.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Grades.Persistence.Context
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Faculty> Faculties { get; set; }
		public DbSet<Semester> Semesters { get; set; }
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
           .HasDiscriminator<string>("Discriminator")
           .HasValue<ApplicationUser>("ApplicationUser");

            modelBuilder.Entity<Faculty>().HasData(
                new Faculty { Id = Guid.NewGuid(), Name = "Faculty 1", Abbreviation = "F1" },
                new Faculty { Id = Guid.NewGuid(), Name = "Faculty 2", Abbreviation = "F2" }
            );

            modelBuilder.Entity<Semester>().HasData(
                new Semester(1, 2022) { Id = Guid.NewGuid() },
                new Semester(2, 2022) { Id = Guid.NewGuid() }
            );

            modelBuilder.Entity<ApplicationUser>().HasData(
                  new ApplicationUser
                  {
                      Id = "49b754b0-8831-4b1a-a44f-8e18a0c2578e",
                      Name = "Admin",
                      Abbreviation = "A",
                      Email = "admin@gmail.com",
                      UserName = "admin@gmail.com",
                      NormalizedUserName = "ADMIN@GMAIL.COM",
                      NormalizedEmail = "ADMIN@GMAIL.COM",
                      EmailConfirmed = true,
                      PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Admin123!")
                  },
                  new ApplicationUser
                  {
                      Id = "edb4f3c1-cf69-4b07-aafb-915d6d58f23d",
                      Name = "Economy Faculty",
                      Abbreviation = "EC",
                      Email = "economy@gmail.com",
                      UserName = "economy@gmail.com",
                      NormalizedUserName = "ECONOMY@GMAIL.COM",
                      NormalizedEmail = "ECONOMY@GMAIL.COM",
                      EmailConfirmed = true,
                      PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Economy123!")
                  },
                  new ApplicationUser
                  {
                      Id = "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45",
                      Name = "Law Faculty",
                      Abbreviation = "LF",
                      Email = "law@gmail.com",
                      UserName = "law@gmail.com",
                      NormalizedUserName = "LAW@GMAIL.COM",
                      NormalizedEmail = "LAW@GMAIL.COM",
                      EmailConfirmed = true,
                      PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Law123!")
                  },
                  new ApplicationUser
                  {
                      Id = "c8b05623-d42b-4a9f-947e-dcd54538ee1d",
                      Name = "User",
                      Abbreviation = "U",
                      Email = "user@gmail.com",
                      UserName = "user@gmail.com",
                      NormalizedUserName = "USER@GMAIL.COM",
                      NormalizedEmail = "USER@GMAIL.COM",
                      EmailConfirmed = true,
                      PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "User123!")
                  });

            modelBuilder.Entity<IdentityRole>().HasData(
                 new IdentityRole
                 {
                     Id = "1",
                     Name = SD.Role_Admin,
                     NormalizedName = SD.Role_Admin.ToUpper(),
                     ConcurrencyStamp = Guid.NewGuid().ToString()
                 },
                 new IdentityRole
                 {
                     Id = "2",
                     Name = SD.Role_Faculty,
                     NormalizedName = SD.Role_Faculty.ToUpper(),
                     ConcurrencyStamp = Guid.NewGuid().ToString()
                 },
                 new IdentityRole
                 {
                     Id = "3",
                     Name = SD.Role_User,
                     NormalizedName = SD.Role_User.ToUpper(),
                     ConcurrencyStamp = Guid.NewGuid().ToString()
                 });


            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                  new IdentityUserRole<string> { UserId = "49b754b0-8831-4b1a-a44f-8e18a0c2578e", RoleId = "1" },
                  new IdentityUserRole<string> { UserId = "edb4f3c1-cf69-4b07-aafb-915d6d58f23d", RoleId = "2" },
                  new IdentityUserRole<string> { UserId = "7e7b3d2d-9a90-4f90-aa5f-2c33d830cf45", RoleId = "2" },
                  new IdentityUserRole<string> { UserId = "c8b05623-d42b-4a9f-947e-dcd54538ee1d", RoleId = "3" });


        }
	}
}
