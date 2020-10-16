using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace web_basics.data.Repositories
{
  public class Cat
  {
    WebBasicsDBContext _webBasicsDbContext;

    public Cat(WebBasicsDBContext context)
    {
      _webBasicsDbContext = context;
    }

    public IEnumerable<Entities.Cat> Get()
    {
      var cats = _webBasicsDbContext.Cats.ToList();
      return cats;
    }
  }
}
