using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace web_basics.data.Repositories
{
  public class Cat
  {
    WebBasicsDBContext _context;

    public Cat(WebBasicsDBContext context)
    {
      _context = context;
    }

    public IEnumerable<Entities.Cat> Get()
    {
      var cats = _context.Cats.ToList();
      return cats;
    }
  }
}
