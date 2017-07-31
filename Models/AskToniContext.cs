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
                _client = new MongoClient("mongodb://admin:Vv33T12Rt@cluster0-shard-00-00-d8sqa.mongodb.net:27017,cluster0-shard-00-01-d8sqa.mongodb.net:27017,cluster0-shard-00-02-d8sqa.mongodb.net:27017/<DATABASE>?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin");
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