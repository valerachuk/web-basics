using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MyVetCenter.Data.Enums;
using MyVetCenter.Data.Interfaces;

namespace MyVetCenter.Data.Entities
{
  public class Animal : IEntity, IPropsToString
  {
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public DateTime RegistrationDate { get; set; }
    [BsonRepresentation(BsonType.String)]
    public AnimalKind AnimalKind { get; set; }
    public Owner Owner { get; set; }
  }
}
