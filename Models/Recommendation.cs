using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections;

namespace AskToniApi.Models
{
    public class Recommendation
    {
        [BsonId]
        public long Id { get; set; }

        public string RestaurantName { get; set; }

        public string Address { get; set; }
        
        public string Website { get; set; }
    }
}