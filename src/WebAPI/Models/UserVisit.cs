using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class UserVisit
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    [BsonElement("VisitId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string VisitId {get; set;}

    [BsonElement("UserId")]
    public string UserId {get; set;}
}