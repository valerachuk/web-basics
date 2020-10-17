using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using web_basics.data.Entities;

namespace web_basics.data
{
  public class WebBasicsDBContext : DbContext
  {
    IConfiguration _configuration;

    public WebBasicsDBContext(DbContextOptions contextOptions) : base(contextOptions)
    {
      DbInitializer.Initialize(this);
    }

    public DbSet<Cat> Cats { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Owner> Owners { get; set; }
  }
}
