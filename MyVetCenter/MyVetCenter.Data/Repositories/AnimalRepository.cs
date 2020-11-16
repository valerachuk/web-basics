using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MyVetCenter.Data.Entities;
using MyVetCenter.Data.Views;

namespace MyVetCenter.Data.Repositories
{
  public class AnimalRepository : Repository<Animal>
  {
    private const int PAGE_SIZE = 3;

    public AnimalRepository(IMongoDatabase database) : base(database)
    {
      var indexKeysDefinition = Builders<Animal>.IndexKeys.Descending(hamster => hamster.RegistrationDate);
      Collection.Indexes.CreateOne(new CreateIndexModel<Animal>(indexKeysDefinition));
    }

    public IEnumerable<Animal> GetPaginated(int pageNumber)
      => Collection
        .Find(_ => true)
        .SortByDescending(a => a.RegistrationDate)
        .Skip(PAGE_SIZE * pageNumber)
        .Limit(PAGE_SIZE)
        .ToList();

    public IEnumerable<AnimalReport> GetKindCountReport()
      => Collection
        .Aggregate()
        .Group(a => a.AnimalKind, g => new AnimalReport {AnimalKind = g.Key, Count = g.Count()})
        .ToList();

  }
}
