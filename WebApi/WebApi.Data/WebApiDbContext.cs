using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entities;

namespace WebApi.Data
{
  public sealed class WebApiDbContext : DbContext, IWebApiDbContext
  {
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public WebApiDbContext(DbContextOptions contextOptions) : base(contextOptions)
    {
      Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      var bookBuilder = modelBuilder.Entity<Book>();

      bookBuilder
        .Property(book => book.Author)
        .IsRequired();
      
      bookBuilder
        .Property(book => book.Name)
        .IsRequired();
      
      bookBuilder
        .Property(book => book.Publisher)
        .IsRequired();

      var genreBuilder = modelBuilder.Entity<Genre>();

      genreBuilder
        .Property(genre => genre.Name)
        .IsRequired();

      genreBuilder
        .HasMany(genre => genre.Books)
        .WithOne(book => book.Genre)
        .HasForeignKey(book => book.GenreId)
        .OnDelete(DeleteBehavior.SetNull);

      genreBuilder
        .HasData(new[]
        {
          new Genre
          {
            Name = "Magic",
            Id = 1
          },
          new Genre
          {
            Name = "Sci-Fi",
            Id = 2
          }
        });

      bookBuilder
        .HasData(new[]
        {
          new Book
          {
            Id = 1,
            Name = "Harry Potter and the Deathly Hallows – Part 2",
            Publisher = "UaBook",
            Author = "J. K. Rowling",
            PublishingYear = 1997,
            GenreId = 1
          },
          new Book
          {
            Id = 2,
            Name = "Человек-амфибия",
            Publisher = "USSRBook",
            Author = "Беляев",
            PublishingYear = 1928,
            GenreId = 2
          }
        });

    }
  }
}
