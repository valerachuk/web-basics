using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace web_basics.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CatController : ControllerBase
  {
    business.Domains.Cat _domain;

    public CatController(business.Domains.Cat domain)
    {
      _domain = domain;
    }

    [HttpGet]
    public IActionResult Get()
    {
      var cats = this._domain.Get();
      return Ok(cats);
    }
  }
}
