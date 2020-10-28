using Microsoft.AspNetCore.Mvc;
using WebApi.Business.Domains.Interfaces;
using WebApi.Business.ViewModels;

namespace WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GenreController : ControllerBase
  {
    private readonly IGenreDomain _genreDomain;

    public GenreController(IGenreDomain genreDomain)
    {
      _genreDomain = genreDomain;
    }

    [HttpGet("books/{genreId}")]
    public IActionResult GetBooks(int genreId)
      => Ok(_genreDomain.GetBooks(genreId));

    [HttpGet]
    public IActionResult Get()
      => Ok(_genreDomain.Get());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
      => Ok(_genreDomain.Get(id));

    [HttpPost]
    public IActionResult Post(GenreViewModel genre)
    {
      genre.Id = null;
      var id = _genreDomain.Add(genre);
      return Ok(new
      {
        Id = id
      });
    }

    [HttpPut]
    public IActionResult Put(GenreViewModel genre)
    {
      if (genre.Id == null)
      {
        return BadRequest(new
        {
          Error = "Id is not specified"
        });
      }

      _genreDomain.Update(genre);
      return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
      _genreDomain.Delete(id);
      return Ok();
    }

  }
}
