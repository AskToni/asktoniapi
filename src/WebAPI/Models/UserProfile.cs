using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections;
using System.Collections.Generic;

namespace AskToniApi.Models
{
    public class UserProfile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name {get; set;}

        [BsonElement("Email")]
        public string Email {get; set;}

        [BsonElement("CategoryPreferences")]
        public List<string> CategoryPreferences {get; set;}

        [BsonElement("FavouriteRestaurants")]
        public List<string> FavouriteRestaurants {get; set;}
    }
}