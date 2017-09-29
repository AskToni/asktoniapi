using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Visit
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    [BsonElement("RestaurantMongoId")]
    public string RestaurantMongoId {get; set;}

    [BsonElement("RestaurantYelpId")]
    public string RestaurantYelpId {get; set;}
    
    [BsonElement("VisitDate")]
    public MongoDB.Bson.BsonDateTime VisitDate {get; set;}
}