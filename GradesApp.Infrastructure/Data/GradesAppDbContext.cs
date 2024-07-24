using GradesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GradesApp.Infrastructure.Data;

public class GradesAppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<User> Users { get; set; }
    
    public GradesAppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Seed();
    }
}