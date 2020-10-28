using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Business.ViewModels
{
  public class GenreViewModel
  {
    public int? Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public IEnumerable<int> Books { get; set; }
  }
}
