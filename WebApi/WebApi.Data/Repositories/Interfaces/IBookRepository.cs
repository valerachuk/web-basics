using System.Collections.Generic;
using WebApi.Data.Entities;

namespace WebApi.Data.Repositories.Interfaces
{
  public interface IBookRepository
  {
    IEnumerable<Book> Get();
    Book Get(int id);
    void Add(Book book);
    void Update(Book book);
    void Delete(int id);
  }
}
