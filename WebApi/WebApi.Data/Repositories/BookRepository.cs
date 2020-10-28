using System.Collections.Generic;
using System.Linq;
using WebApi.Data.Entities;
using WebApi.Data.Repositories.Interfaces;

namespace WebApi.Data.Repositories
{
  public class BookRepository : IBookRepository
  {
    private readonly IWebApiDbContext _dbContext;

    public BookRepository(IWebApiDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public IEnumerable<Book> Get()
      => _dbContext.Books.ToList();

    public Book Get(int id)
      => _dbContext.Books.FirstOrDefault(book => book.Id == id);

    public void Add(Book book)
    {
      _dbContext.Books.Add(book);
      _dbContext.SaveChanges();
    }

    public void Update(Book book)
    {
      _dbContext.Books.Update(book);
      _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
      _dbContext.Books.Remove(new Book
      {
        Id = id
      });
      _dbContext.SaveChanges();
    }
  }
}
