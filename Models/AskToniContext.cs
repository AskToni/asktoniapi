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

        public AskToniContext()
        {
            try {
                _client = new MongoClient("mongodb://admin:Vv33T$Rt@ds034677.mlab.com:34677/asktonidb");
                _db = _client.GetDatabase("asktonidb"); 
            } catch (Exception ex) {
                throw ex;
            }  
        }

        public IMongoCollection<Recommendation> Recommendations
        {
            get
            {
                return _db.GetCollection<Recommendation>("restaurants");
            }
        }
    }
}