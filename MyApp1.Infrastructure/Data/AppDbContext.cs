using Microsoft.EntityFrameworkCore;
using MyApp1.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MyApp1.Infrastructure.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Teacher> Teachers => Set<Teacher>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      // keep simple — default conventions are fine for academic work
    }
  }
}
