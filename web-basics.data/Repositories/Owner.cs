using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Linq;

namespace web_basics.data.Repositories
{
  public class Owner
  {
    WebBasicsDBContext _context;

    public Owner(WebBasicsDBContext context)
    {
      _context = context;
    }

    public IEnumerable<Entities.Owner> Get()
    {
      var owners = _context.Owners.ToList();
      return owners;
    }
  }
}
