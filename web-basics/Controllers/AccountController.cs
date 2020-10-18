using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_basics.business.ViewModels;

namespace web_basics.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize(Roles = "Admin")]
  public class AccountController : ControllerBase
  {
    private readonly business.Domains.Account _accountDomain;

    public AccountController(business.Domains.Account accountDomain)
    {
      _accountDomain = accountDomain;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok(_accountDomain.Get());
    }

    [HttpPut]
    public IActionResult Update(Account account)
    {
      _accountDomain.Update(account);
      return Ok();
    }

    [HttpPost]
    public IActionResult Create(Login login)
    {
      if (_accountDomain.Exists(login.Email))
      {
        return Conflict();
      }

      _accountDomain.Add(login);
      return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
      //User.Claims.FirstOrDefault(cl => cl.Subject)
      _accountDomain.Delete(id);
      return Ok();
    }

  }
}
