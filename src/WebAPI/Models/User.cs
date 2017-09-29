using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    [BsonElement("FirstName")]
    public string FirstName {get; set;}

    [BsonElement("LastName")]
    public string LastName {get; set;}
}