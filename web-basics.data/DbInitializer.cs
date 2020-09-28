using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using web_basics.data.Entities;

namespace web_basics.data
{
    public static class DbInitializer
    {
        public static void Initialize(WebBasicsDBContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Cats.Any())
            {
                context.Cats.AddRange(new Entities.Cat[] {
                    new Entities.Cat() { Name = "Barsik", Age = 3 },
                    new Entities.Cat() { Name = "Kozkii", Age = 4 },
                    new Entities.Cat() { Name = "Murka", Age = 13 },
                    new Entities.Cat() { Name = "Bony", Age = 2 }
                });
            }

            if (!context.Accounts.Any())
            {
                context.Accounts.AddRange(new Entities.Account[] {
                    new Entities.Account() { Email = "user1@email.com", Password = "111111", Role = Role.User },
                    new Entities.Account() { Email = "user2@email.com", Password = "222222", Role = Role.User },
                    new Entities.Account() { Email = "admin@email.com", Password = "password", Role = Role.Admin }
                });
            }

            context.SaveChanges();
        }
    }
}
