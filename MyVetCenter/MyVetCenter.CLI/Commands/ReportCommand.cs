using System.Linq;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using MyVetCenter.Data.Interfaces;
using MyVetCenter.Data.Repositories;

namespace MyVetCenter.CLI.Commands
{
  [Command("report", Description = "Generates report")]
  public class ReportCommand : ICommand
  {
    private readonly AnimalRepository _animalRepository;

    public ReportCommand(AnimalRepository animalRepository)
    {
      _animalRepository = animalRepository;
    }

    public ValueTask ExecuteAsync(IConsole console)
    {
      var output = _animalRepository
        .GetKindCountReport()
        .Select(view => ((IPropsToString)view).AllPropsToString())
        .Aggregate((acc, x) => $"{acc}\n\n{x}");

      console.Output.WriteLine(output);
      return default;
    }
  }
}
