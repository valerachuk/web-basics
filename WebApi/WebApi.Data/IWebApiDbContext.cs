using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entities;

namespace WebApi.Data
{
  public interface IWebApiDbContext
  {
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }

    int SaveChanges();
  }
}
