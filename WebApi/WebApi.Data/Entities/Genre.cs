using System.Collections.Generic;

namespace WebApi.Data.Entities
{
  public class Genre
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Book> Books { get; set; }
  }
}
