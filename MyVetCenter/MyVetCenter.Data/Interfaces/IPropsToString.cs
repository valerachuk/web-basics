using System.Linq;

namespace MyVetCenter.Data.Interfaces
{
  public interface IPropsToString
  {
    public string AllPropsToString()
      => GetType()
        .GetProperties()
        .Select(prop => $"{prop.Name}: {(prop.GetValue(this) as IPropsToString)?.AllPropsToString() ?? prop.GetValue(this)?.ToString() }")
        .Aggregate((acc, x) => $"{acc}\n{x}");
  }
}
