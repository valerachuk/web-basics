using MyVetCenter.Data.Enums;
using MyVetCenter.Data.Interfaces;

namespace MyVetCenter.Data.Views
{
  public class AnimalReport : IPropsToString
  {
    public AnimalKind AnimalKind { get; set; }
    public int Count { get; set; }
  }
}
