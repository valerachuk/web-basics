namespace EFCoreHomework.Entities
{
  internal class Student
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Group Group { get; set; }
    public int GroupId { get; set; }
  }
}
