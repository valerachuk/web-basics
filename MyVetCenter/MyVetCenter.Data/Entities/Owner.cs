using MyVetCenter.Data.Interfaces;

namespace MyVetCenter.Data.Entities
{
  public class Owner : IPropsToString
  {
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
  }
}
