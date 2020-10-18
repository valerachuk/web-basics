using System.Collections.Generic;

namespace EFCoreHomework.Entities
{
  internal class Group
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; }

    public ICollection<Student> Students { get; set; }
  }
}
