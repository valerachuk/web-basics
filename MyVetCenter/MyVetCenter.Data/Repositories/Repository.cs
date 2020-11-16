using System.Collections.Generic;
using MongoDB.Driver;
using MyVetCenter.Data.Interfaces;

namespace MyVetCenter.Data.Repositories
{
  public abstract class Repository<TEntity> where TEntity : IEntity
  {
    protected IMongoCollection<TEntity> Collection { get; private set; }

    protected Repository(IMongoDatabase database)
    {
      Collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
    }

    public void InsertMany(IEnumerable<TEntity> entities)
      => Collection.InsertMany(entities);

    public long GetCount()
      => Collection.EstimatedDocumentCount();
  }
}
