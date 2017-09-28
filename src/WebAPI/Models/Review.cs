using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Review
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("RestaurantId")]
    public string RestaurantId {get; set;}
    [BsonElement("Text")]
    public string Text {get; set;}
    [BsonElement("RestaurantName")]
    public string RestaurantName { get; set;}

    [BsonElement("Rating")]
    public double Rating { get; set;}
    [BsonElement("UserId")]
    public string UserId { get;set; }
}