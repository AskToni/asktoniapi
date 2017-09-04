using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections;
using System.Collections.Generic;

namespace AskToniApi.Models
{
    public class Restaurant
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("RestaurantId")]
        public string RestaurantId { get; set;}
        
        [BsonElement("RestaurantName")]
        public string RestaurantName { get; set;}
        
        [BsonElement("ReviewCount")]
        public int ReviewCount { get; set;}
        
        [BsonElement("Rating")]
        public double Rating { get; set;}
        
        [BsonElement("Price")]
        public string Price { get; set;}
        
        [BsonElement("Address")]
        public string Address {get; set;}
        
        [BsonElement("City")]
        public string City {get; set;}
        
        [BsonElement("ZipCode")]
        public string ZipCode {get; set;}
        
        [BsonElement("Phone")]
        public string Phone { get; set;}
        
        [BsonElement("Categories")]
        public List<string> Categories {get; set;}

        [BsonElement("ReviewIDs")]
        public List<string> ReviewIDs { get; set;}
    }
}