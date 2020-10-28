using Microsoft.AspNetCore.Mvc;
using WebApi.Business.Domains.Interfaces;
using WebApi.Business.ViewModels;

namespace WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BookController : ControllerBase
  {
    private readonly IBookDomain _bookDomain;

    public BookController(IBookDomain bookDomain)
    {
      _bookDomain = bookDomain;
    }

    [HttpGet]
    public IActionResult Get()
      => Ok(_bookDomain.Get());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
      => Ok(_bookDomain.Get(id));

    [HttpPost]
    public IActionResult Post(BookViewModel book)
    {
      book.Id = null;
      var id = _bookDomain.Add(book);
      return Ok(new
      {
        Id = id
      });
    }

    [HttpPut]
    public IActionResult Put(BookViewModel book)
    {
      if (book.Id == null)
      {
        return BadRequest(new
        {
          Error = "Id is not specified"
        });
      }

      _bookDomain.Update(book);

      return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
      _bookDomain.Delete(id);
      return Ok();
    }
  }
}
