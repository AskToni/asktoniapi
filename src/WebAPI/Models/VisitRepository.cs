using AskToniApi.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Options;

public class VisitRepository : IVisitRepository
{
    private readonly AskToniContext _context = null;

    public VisitRepository(IOptions<DbConnectionConfig> dbConnectionConfig)
    {
        DbConnectionConfig _dbConnectionConfig = dbConnectionConfig.Value;
        _context = new AskToniContext(_dbConnectionConfig.mLabConnectStr);
    }

    public async Task<IEnumerable<Visit>> GetAllVisitsToARestaurant(string restaurantMongoId, int pageOffset, int pageLimit)
    {
        try {
            var filter = Builders<Visit>.Filter.Eq(v => v.RestaurantMongoId, restaurantMongoId);
            return await _context.Visits.Find(filter).Skip(pageOffset*pageLimit).Limit(pageLimit).ToListAsync();
        }
        catch (Exception ex) {
            throw ex;
        }
    }

    public async Task<IEnumerable<Visit>> GetAllVisitsToARestaurant(string restaurantMongoId)
    {
        try {
            var filter = Builders<Visit>.Filter.Eq(v => v.RestaurantMongoId, restaurantMongoId);
            return await _context.Visits.Find(filter).ToListAsync();
        }
        catch (Exception ex) {
            throw ex;
        }
    }

    public async Task<IEnumerable<Visit>> GetAllVisits()
    {
        try {
            return await _context.Visits.Find(_ => true).ToListAsync();
        }
        catch (Exception ex) {
            throw ex;
        }
    }

    public async Task<IEnumerable<Visit>> GetVisitsUsingFilter(int pageOffset, int pageLimit)
    {
        try {
            return await _context.Visits.Find(_ => true).Skip(pageOffset*pageLimit).Limit(pageLimit).ToListAsync();
        }
        catch (Exception ex) {
            throw ex;
        }
    }

    public async Task<Visit> GetVisit(string id)
    {
        var filter = Builders<Visit>.Filter.Eq(r => r.Id, id);
        return await _context.Visits
                             .Find(filter)
                             .FirstOrDefaultAsync();
    }

    public async Task AddVisit(Visit item)
    {
        await _context.Visits.InsertOneAsync(item);
    }

    public async Task<DeleteResult> RemoveVisit(string id)
    {
        return await _context.Visits.DeleteOneAsync(
                     Builders<Visit>.Filter.Eq(r => r.Id, id));
    }
   
    public async Task<ReplaceOneResult> UpdateVisit(string id, Visit item)
    {
        item.Id = id;

        return await _context.Visits
                             .ReplaceOneAsync(r => r.Id.Equals(ObjectId.Parse(id)),
                                             item,
                                             new UpdateOptions { IsUpsert = true });
    }

    public async Task AddUserToVisit(string userId, string visitId)
    {
        var userVisit = new UserVisit(){ UserId = userId,
                                    VisitId = visitId};
        await _context.UserVisits.InsertOneAsync(userVisit);
    }
}