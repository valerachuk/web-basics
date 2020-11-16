using System;
using System.Collections.Generic;
using MyVetCenter.Data.Entities;
using MyVetCenter.Data.Enums;

namespace MyVetCenter.Data.Mock
{
  public static class AnimalsMock
  {
    public static IEnumerable<Animal> Get()
      => new[]
      {
        new Animal
        {
          AnimalKind = AnimalKind.Bird,
          Name = "Арчи",
          Owner = new Owner
          {
            Name = "Ivan",
            PhoneNumber = "1317341102120"
          },
          RegistrationDate = new DateTime(2019, 3, 28)
        },
        
        new Animal
        {
          AnimalKind = AnimalKind.Bird,
          Name = "Кеша",
          Owner = new Owner
          {
            Name = "Olga",
            PhoneNumber = "210402140"
          },
          RegistrationDate = new DateTime(2019, 9, 3)
        },
        
        new Animal
        {
          AnimalKind = AnimalKind.Bird,
          Name = "Ричи",
          Owner = new Owner
          {
            Name = "Anton",
            PhoneNumber = "1255615161"
          },
          RegistrationDate = new DateTime(2020, 1, 2)
        },
        
        new Animal
        {
          AnimalKind = AnimalKind.Bird,
          Name = "Ася",
          Owner = new Owner
          {
            Name = "Dima",
            PhoneNumber = "119030152"
          },
          RegistrationDate = new DateTime(2020, 6, 8)
        },
        
        new Animal
        {
          AnimalKind = AnimalKind.Bird,
          Name = "Лимончик",
          Owner = new Owner
          {
            Name = "Albert",
            PhoneNumber = "1020210290"
          },
          RegistrationDate = new DateTime(2020, 7, 18)
        },
        
        new Animal
        {
          AnimalKind = AnimalKind.Dog,
          Name = "Тaйсон",
          Owner = new Owner
          {
            Name = "Sergei",
            PhoneNumber = "1139575875"
          },
          RegistrationDate = new DateTime(2018, 11, 11)
        },
        
        new Animal
        {
          AnimalKind = AnimalKind.Dog,
          Name = "Джек",
          Owner = new Owner
          {
            Name = "Vlas",
            PhoneNumber = "83891357158"
          },
          RegistrationDate = new DateTime(2020, 10, 23)
        },
        
        new Animal
        {
          AnimalKind = AnimalKind.Dog,
          Name = "Хатико",
          Owner = new Owner
          {
            Name = "Vlad",
            PhoneNumber = "13089358913859"
          },
          RegistrationDate = new DateTime(2018, 1, 2)
        },
        
        new Animal
        {
          AnimalKind = AnimalKind.Dog,
          Name = "Татошка",
          Owner = new Owner
          {
            Name = "Ihor",
            PhoneNumber = "1835825782189"
          },
          RegistrationDate = new DateTime(2018, 8, 12)
        },

        new Animal
        {
          AnimalKind = AnimalKind.Cat,
          Name = "Барсик",
          Owner = new Owner
          {
            Name = "Lera",
            PhoneNumber = "135483185"
          },
          RegistrationDate = new DateTime(2019, 12, 14)
        },

        new Animal
        {
          AnimalKind = AnimalKind.Cat,
          Name = "Ася",
          Owner = new Owner
          {
            Name = "Sasha",
            PhoneNumber = "78535678"
          },
          RegistrationDate = new DateTime(2018, 8, 17)
        },

        new Animal
        {
          AnimalKind = AnimalKind.Cat,
          Name = "Дымок",
          Owner = new Owner
          {
            Name = "Pasha",
            PhoneNumber = "52736781357813"
          },
          RegistrationDate = new DateTime(2019, 5, 26)
        }

      };
  }
}
