using System.Collections.Generic;
using WebApi.Business.ViewModels;

namespace WebApi.Business.Domains.Interfaces
{
  public interface IBookDomain
  {
    IEnumerable<BookViewModel> Get();
    BookViewModel Get(int id);
    int Add(BookViewModel book);
    void Update(BookViewModel book);
    void Delete(int id);
  }
}
