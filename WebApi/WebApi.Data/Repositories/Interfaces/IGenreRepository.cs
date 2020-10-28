using System.Collections.Generic;
using WebApi.Data.Entities;

namespace WebApi.Data.Repositories.Interfaces
{
  public interface IGenreRepository
  {
    IEnumerable<Genre> Get();
    Genre Get(int id);
    IEnumerable<Book> GetBooks(int genreId);
    void Add(Genre genre);
    void Update(Genre genre);
    void Delete(int id);
  }
}
