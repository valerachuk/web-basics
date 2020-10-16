using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using web_basics.business.Domains;
using web_basics.business.ViewModels;

namespace web_basics.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DogController : ControllerBase
  {
    private business.Domains.Dog _domain;

    public DogController(business.Domains.Dog domain)
    {
      _domain = domain;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_domain.Get());

    [HttpPost]
    public IActionResult Post([FromBody] DogRequest dogRequest)
    {
      _domain.Add(dogRequest);
      return Ok();
    }
  }
}
