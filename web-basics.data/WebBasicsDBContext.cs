using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using web_basics.data.Entities;

namespace web_basics.data
{
  public class WebBasicsDBContext : DbContext
  {
    public WebBasicsDBContext(DbContextOptions contextOptions) : base(contextOptions)
    {
      Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Dog>().HasData(new[]
      {
        new Entities.Dog {Id = 1, Name = "Barya", Age = 7, Weight = 32},
        new Entities.Dog {Id = 2, Name = "Bobik", Age = 1, Weight = 6},
        new Entities.Dog {Id = 3, Name = "Richi", Age = 5, Weight = 34},
        new Entities.Dog {Id = 4, Name = "Rex", Age = 6, Weight = 87},
      });

      modelBuilder.Entity<Cat>().HasData(new []
      {
        new Entities.Cat {Id = 1, Name = "Kozkii", Age = 4},
        new Entities.Cat {Id = 2, Name = "Barsik", Age = 3},
        new Entities.Cat {Id = 3, Name = "Murka", Age = 13},
        new Entities.Cat {Id = 4, Name = "Bony", Age = 2}
      });
    }

    public DbSet<Cat> Cats { get; set; }
    public DbSet<Dog> Dogs { get; set; }
  }
}
