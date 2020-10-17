using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace web_basics.data.Repositories
{
  public class Account
  {
    WebBasicsDBContext _context;

    public Account(WebBasicsDBContext context)
    {
      _context = context;
    }

    public IEnumerable<Entities.Account> Get()
    {
      var accounts = _context.Accounts.ToList();
      return accounts;
    }
  }
}
