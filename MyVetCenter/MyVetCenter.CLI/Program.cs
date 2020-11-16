using System;
using System.Threading.Tasks;
using CliFx;
using MongoDB.Driver;
using MyVetCenter.Data.Mock;
using MyVetCenter.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MyVetCenter.CLI.Commands;

namespace MyVetCenter.CLI
{
  internal class Program
  {
    public static async Task<int> Main(string[] args)
    {
      Console.OutputEncoding = System.Text.Encoding.UTF8;

      var client = new MongoClient("mongodb://localhost:27017");
      var database = client.GetDatabase("testdb");
      var animalRepository = new AnimalRepository(database);

      if (animalRepository.GetCount() == 0)
        animalRepository.InsertMany(AnimalsMock.Get());

      var services = new ServiceCollection();

      services.AddSingleton(animalRepository);
      services.AddTransient<ReportCommand>();
      services.AddTransient<PageCommand>();

      return await new CliApplicationBuilder()
        .AddCommandsFromThisAssembly()
        .UseTypeActivator(services.BuildServiceProvider().GetService)
        .Build()
        .RunAsync(args);
    }

  }
}
