﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using web_basics.business.ViewModels;

namespace web_basics.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OwnerController : ControllerBase
  {
    private business.Domains.Cat _catDomain;
    private business.Domains.Owner _ownerDomain;

    private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

    public OwnerController(business.Domains.Cat catDomain, business.Domains.Owner ownerDomain)
    {
      _catDomain = catDomain;
      _ownerDomain = ownerDomain;
    }

    [HttpGet]
    [Authorize(Roles = "User")]
    [Route("")]
    public IActionResult GetPets()
    {
      if (!_ownerDomain.Get().Any(owner => owner.UserId == UserId))
      {
        return Ok(Enumerable.Empty<Cat>());
      }

      var catsOwner = _ownerDomain.Get().Where(owner => owner.UserId == UserId);
      var cats = _catDomain.Get().Where(cat => catsOwner.Any(owner => owner.CatId == cat.Id));

      return Ok(cats);
    }
  }
}
