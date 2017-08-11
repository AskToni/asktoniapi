using AskToniApi.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Options;

public class RecommendationRepository : IRecommendationRepository
{
    private readonly AskToniContext _context = null;

    public RecommendationRepository(IOptions<DbConnectionConfig> dbConnectionConfig)
    {
        DbConnectionConfig _dbConnectionConfig = dbConnectionConfig.Value;
        _context = new AskToniContext(_dbConnectionConfig.mLabConnectStr);
    }

    public async Task<IEnumerable<Recommendation>> GetAllRecommendations()
    {
        try {
            return await _context.Recommendations.Find(_ => true).ToListAsync();
        }
        catch (Exception ex) {
            throw ex;
        }
    }

    public async Task<Recommendation> GetRecommendation(string id)
    {
        var filter = Builders<Recommendation>.Filter.Eq("Id", id);
        return await _context.Recommendations
                             .Find(filter)
                             .FirstOrDefaultAsync();
    }

    public async Task AddRecommendation(Recommendation item)
    {
        await _context.Recommendations.InsertOneAsync(item);
    }

    public async Task<DeleteResult> RemoveRecommendation(string id)
    {
        return await _context.Recommendations.DeleteOneAsync(
                     Builders<Recommendation>.Filter.Eq("Id", id));
    }
   
    public async Task<ReplaceOneResult> UpdateRecommendation(string id, Recommendation item)
    {
        return await _context.Recommendations
                             .ReplaceOneAsync(n => n.Id.Equals(id)
                                                 , item
                                                 , new UpdateOptions { IsUpsert = true });
    }

    public async Task<DeleteResult> RemoveAllRecommendations()
    {
        return await _context.Recommendations.DeleteManyAsync(new BsonDocument());
    }
}