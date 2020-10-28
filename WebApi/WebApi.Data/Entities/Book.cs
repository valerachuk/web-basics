﻿namespace WebApi.Data.Entities
{
  public class Book
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public int PublishingYear { get; set; }
    public string Publisher { get; set; }

    public int? GenreId { get; set; }
    public Genre Genre { get; set; }
  }
}
