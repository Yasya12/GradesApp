using Grades.Domain.Entities;
using Grades.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Grades.Persistence.Context
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Faculty> Faculties { get; set; }
		public DbSet<Semester> Semesters { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Seed Faculty data
			modelBuilder.Entity<Faculty>().HasData(
				new Faculty { Id = Guid.NewGuid(), Name = "Faculty 1", Abbreviation = "F1" },
				new Faculty { Id = Guid.NewGuid(), Name = "Faculty 2", Abbreviation = "F2" }
			);

			// Seed Semester data
			modelBuilder.Entity<Semester>().HasData(
				new Semester(1, 2022) { Id = Guid.NewGuid() },
				new Semester(2, 2022) { Id = Guid.NewGuid() }
			);
		}
	}
}
