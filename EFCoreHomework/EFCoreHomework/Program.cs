using System;
using System.Collections.Generic;
using System.Linq;
using EFCoreHomework.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreHomework
{
  internal class Program
  {
    private static MyDbContext _dbContext;

    private static void PrintDb()
    {
      _dbContext
        .Faculties
        .Include(faculty => faculty.Groups)
        .ThenInclude(group => group.Students)
        .ToList()
        .ForEach(faculty =>
        {
          Console.WriteLine($"|FACULTY Name: {faculty.Name}, Id: {faculty.Id}");
          faculty
            .Groups
            .ToList()
            .ForEach(group =>
            {
              Console.WriteLine($"|\t|GROUP Name: {group.Name}, Id: {group.Id}");
              group
                .Students
                .ToList()
                .ForEach(student =>
                {
                  Console.WriteLine($"|\t|\t|STUDENT Name: {student.Name}, Age: {student.Age}, Id: {student.Id}");
                });
            });
        });
    }

    private static void AddFaculty()
    {
      using var transaction = _dbContext.Database.BeginTransaction();

      var faculty1 = new Faculty
      {
        Name = "Faculty1",
        Groups = new List<Group>
        {
          new Group
          {
            Name = "Group3"
          }
        }
      };

      _dbContext.Faculties.Add(faculty1);
      _dbContext.SaveChanges();

      var group2 = new Group
      {
        Name = "Group1",
        Faculty = faculty1,
        Students = new List<Student>
        {
          new Student
          {
            Name = "Student1",
            Age = 1
          },
          new Student
          {
            Name = "Student2",
            Age = 2
          },
          new Student
          {
            Name = "Student3",
            Age = 3
          }
        }
      };

      var group3 = new Group
      {
        Name = "Group2",
        Faculty = faculty1,
        Students = new List<Student>
        {
          new Student
          {
            Name = "Student4",
            Age = 4
          },
          new Student
          {
            Name = "Student5",
            Age = 5
          }
        }
      };
        
      _dbContext.Groups.AddRange(group2, group3);
      _dbContext.SaveChanges();

      transaction.Commit();
    }

    private static void Main()
    {
      _dbContext = new MyDbContext();
      _dbContext.Database.Migrate();

      AddFaculty();
      PrintDb();
    }
  }
}
