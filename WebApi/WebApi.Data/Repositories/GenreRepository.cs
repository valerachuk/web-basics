using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entities;
using WebApi.Data.Repositories.Interfaces;

namespace WebApi.Data.Repositories
{
  public class GenreRepository : IGenreRepository
  {
    private readonly IWebApiDbContext _dbContext;

    public GenreRepository(IWebApiDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public IEnumerable<Genre> Get()
      => _dbContext.Genres.Include(genre => genre.Books).ToList();

    public Genre Get(int id)
      => _dbContext.Genres.Include(genre => genre.Books).FirstOrDefault(genre => genre.Id == id);

    public IEnumerable<Book> GetBooks(int genreId)
      => _dbContext
          .Genres
          .Include(genre => genre.Books)
          .FirstOrDefault(genre => genre.Id == genreId)?.Books ?? Enumerable.Empty<Book>();

    public void Add(Genre genre)
    {
      _dbContext.Genres.Add(genre);
      _dbContext.SaveChanges();
    }

    public void Update(Genre genre)
    {
      _dbContext.Genres.Update(genre);
      _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
      _dbContext.Genres.Remove(new Genre
      {
        Id = id
      });
      _dbContext.SaveChanges();
    }
  }
}
