using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System;

namespace AskToniApi.Models
{
    public class AskToniContext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _db = null;

        public AskToniContext() {}
        public AskToniContext(string dbConnectionString)
        {
            try {
                _client = new MongoClient(dbConnectionString);
                if(_client != null) {
                    _db = _client.GetDatabase("asktonidb"); 
                }
            } catch (Exception ex) {
                throw ex;
            }  
        }

        public IMongoCollection<Restaurant> Recommendations
        {
            get
            {
                return _db.GetCollection<Restaurant>("restaurants");
            }
        }

        public IMongoCollection<Review> Reviews
        {
            get
            {
                return _db.GetCollection<Review>("reviews");
            }
        }

        public IMongoCollection<Visit> Visits
        {
            get
            {
                return _db.GetCollection<Visit>("visits");
            }
        }

        public IMongoCollection<User> Users
        {
            get
            {
                return _db.GetCollection<User>("users");
            }
        }

        public IMongoCollection<UserVisit> UserVisits
        {
            get
            {
                return _db.GetCollection<UserVisit>("uservisits");
            }
        }
    }
}