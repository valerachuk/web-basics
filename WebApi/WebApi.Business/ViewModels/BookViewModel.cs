using System.ComponentModel.DataAnnotations;

namespace WebApi.Business.ViewModels
{
  public class BookViewModel
  {
    public int? Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Author { get; set; }
    
    [Required]
    public int? PublishingYear { get; set; }
    
    [Required]
    public string Publisher { get; set; }

    [Required]
    public int? GenreId { get; set; }
  }
}
