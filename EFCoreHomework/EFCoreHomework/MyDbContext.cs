using EFCoreHomework.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreHomework
{
  internal class MyDbContext : DbContext
  {
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Faculty> Faculties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=./myDb.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Student>()
        .Property(student => student.Name).HasMaxLength(60);

      modelBuilder.Entity<Group>()
        .Property(group => group.Name).HasMaxLength(20);

      modelBuilder.Entity<Group>()
        .HasMany(group => group.Students)
        .WithOne(student => student.Group)
        .HasForeignKey(student => student.GroupId);

      modelBuilder.Entity<Faculty>()
        .Property(group => group.Name).HasMaxLength(100);

      modelBuilder.Entity<Faculty>()
        .HasMany(faculty => faculty.Groups)
        .WithOne(group => group.Faculty)
        .HasForeignKey(group => group.FacultyId);

    }
  }
}
