using System.Collections.Generic;

namespace EFCoreHomework.Entities
{
  internal class Faculty
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Group> Groups { get; set; }
  }
}
