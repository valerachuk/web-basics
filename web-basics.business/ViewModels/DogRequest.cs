using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace web_basics.business.ViewModels
{
  public class DogRequest
  {
    [Required]
    public string Name { get; set; }

    [Required]
    public int? Age { get; set; }

    [Required]
    public float? Weight { get; set; }
  }
}
