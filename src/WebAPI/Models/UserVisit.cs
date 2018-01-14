using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections;
using System;
using System.Collections.Generic;

namespace AskToniApi.Models
{
    public class UserVisit
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("RestaurantID")]
        public string RestaurantID { get; set;}

        [BsonElement("UserProfileID")]
        public string UserProfileID {get; set;}

        [BsonElement("TimeOfVisit")]
        public DateTime TimeOfVisit {get; set;}

    }
}