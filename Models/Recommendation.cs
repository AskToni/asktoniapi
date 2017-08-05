using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections;

namespace AskToniApi.Models
{
    public class Recommendation
    {
        [BsonId]
        public long Id { get; set; }

        [BsonElement("RestaurantName")]
        public string RestaurantName { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }
        
        [BsonElement("Website")]
        public string Website { get; set; }
    }
}