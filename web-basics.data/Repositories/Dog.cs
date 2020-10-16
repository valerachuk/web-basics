using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace web_basics.data.Repositories
{
  public class Dog
  {
    private WebBasicsDBContext _webBasicsDbContext;

    public Dog(WebBasicsDBContext context)
    {
      _webBasicsDbContext = context;
    }

    public IEnumerable<Entities.Dog> Get() => _webBasicsDbContext.Dogs.ToList();
  }
}
