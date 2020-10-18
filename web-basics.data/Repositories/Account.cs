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

    public void Update(Entities.Account account)
    {
      _context.Accounts.Update(account);
      _context.SaveChanges();
    }

    public void Delete(Entities.Account account)
    {
      _context.Accounts.Remove(account);
      _context.SaveChanges();
    }

    public void Create(Entities.Account account)
    {
      _context.Accounts.Add(account);
      _context.SaveChanges();
    }
  }
}
