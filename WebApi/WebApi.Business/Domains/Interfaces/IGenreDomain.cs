using System.Collections.Generic;
using WebApi.Business.ViewModels;

namespace WebApi.Business.Domains.Interfaces
{
  public interface IGenreDomain
  {
    IEnumerable<GenreViewModel> Get();
    GenreViewModel Get(int id);
    IEnumerable<BookViewModel> GetBooks(int genreId);
    int Add(GenreViewModel genre);
    void Update(GenreViewModel genre);
    void Delete(int id);
  }
}
