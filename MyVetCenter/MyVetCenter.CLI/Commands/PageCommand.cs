using System.Linq;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using MyVetCenter.Data.Interfaces;
using MyVetCenter.Data.Repositories;

namespace MyVetCenter.CLI.Commands
{
  [Command("page", Description = "Returns page with animals info")]
  public class PageCommand : ICommand
  {
    [CommandParameter(0, Name = "pageNumber", Description = "Number of page is required, begins from 0")]
    public int PageNumber { get; set; }

    private const string RECORDINGS_DELIMITER = "---------------------------------------";

    private readonly AnimalRepository _animalRepository;

    public PageCommand(AnimalRepository animalRepository)
    {
      _animalRepository = animalRepository;
    }

    public ValueTask ExecuteAsync(IConsole console)
    {
      var animals = _animalRepository.GetPaginated(PageNumber).ToList();

      string output;

      if (animals.Any())
      {
        output = animals.Select(animal => ((IPropsToString) animal).AllPropsToString())
          .Aggregate("", (x, y) => $"{x}\n{RECORDINGS_DELIMITER}\n{y}");
      }
      else
      {
        output = $"Page {PageNumber} is empty";
      }

      console.Output.WriteLine(output);

      return default;
    }
  }
}
