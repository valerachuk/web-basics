using MongoDB.Bson;

namespace MyVetCenter.Data.Interfaces
{
  public interface IEntity
  {
    public ObjectId Id { get; set; }
  }
}
