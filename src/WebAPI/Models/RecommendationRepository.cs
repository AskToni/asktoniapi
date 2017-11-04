using AskToniApi.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver.Linq;
using GeoCoordinatePortable;

public class RecommendationRepository : IRecommendationRepository
{
    private readonly AskToniContext _context = null;

    public RecommendationRepository(IOptions<DbConnectionConfig> dbConnectionConfig)
    {
        DbConnectionConfig _dbConnectionConfig = dbConnectionConfig.Value;
        _context = new AskToniContext(_dbConnectionConfig.mLabConnectStr);
    }

    public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
    {
        try {
            return await _context.Recommendations.Find(_ => true).ToListAsync();
        }
        catch (Exception ex) {
            throw ex;
        }
    }

    public async Task<IEnumerable<Restaurant>> GetRestaurantsUsingFilter(int pageOffset, int pageLimit)
    {
        try {
            return await _context.Recommendations.Find(_ => true).Skip(pageOffset*pageLimit).Limit(pageLimit).ToListAsync();
        }
        catch (Exception ex) {
            throw ex;
        }
    }

    public async Task<Restaurant> GetRestaurant(string id)
    {
        var filter = Builders<Restaurant>.Filter.Eq(r => r.Id, id);
        return await _context.Recommendations
                             .Find(filter)
                             .FirstOrDefaultAsync();
    }

    public async Task AddRestaurant(Restaurant item)
    {
        await _context.Recommendations.InsertOneAsync(item);
    }

    public async Task<DeleteResult> RemoveRestaurant(string id)
    {
        return await _context.Recommendations.DeleteOneAsync(
                     Builders<Restaurant>.Filter.Eq(r => r.Id, id));
    }
   
    public async Task<ReplaceOneResult> UpdateRestaurant(string id, Restaurant item)
    {
        item.Id = id;

        return await _context.Recommendations
                             .ReplaceOneAsync(r => r.Id.Equals(ObjectId.Parse(id)),
                                             item,
                                             new UpdateOptions { IsUpsert = true });
    }

        public async Task<IEnumerable<Review>> GetAllReviews()
    {
        try {
            return await _context.Reviews.Find(_ => true).ToListAsync();
        }
        catch (Exception ex) {
            throw ex;
        }
    }

    public async Task<Review> GetReview(string id)
    {
        var filter = Builders<Review>.Filter.Eq(r => r.Id, id);
        return await _context.Reviews
                             .Find(filter)
                             .FirstOrDefaultAsync();
    }

    public async Task AddReview(Review item)
    {
        await _context.Reviews.InsertOneAsync(item);
    }

    public async Task<DeleteResult> RemoveReview(string id)
    {
        return await _context.Reviews.DeleteOneAsync(
                     Builders<Review>.Filter.Eq(r => r.Id, id));
    }
   
    public async Task<ReplaceOneResult> UpdateReview(string id, Review item)
    {
        item.Id = id;

        return await _context.Reviews
                             .ReplaceOneAsync(r => r.Id.Equals(ObjectId.Parse(id)),
                                             item,
                                             new UpdateOptions { IsUpsert = true });
    }

    public async Task<IEnumerable<Restaurant>> GetRecommendation(double latitude, double longitude, string category)
    {
        var filter = Builders<Restaurant>.Filter.AnyEq(r => r.Categories, category);
        var relatedRestaurants = await _context.Recommendations.Find(filter).ToListAsync();

        GeoCoordinate userLocation = new GeoCoordinate(latitude,longitude);
        List<Restaurant> recommendationResults = new List<Restaurant>();
        double distanceFromUserLocationInKm = 0.0;
        double distanceThreshold = 5.0;

        foreach (Restaurant r in relatedRestaurants) {
            distanceFromUserLocationInKm = userLocation.GetDistanceTo(new GeoCoordinate(r.Latitude, r.Longitude)) / 1000;

            if (distanceFromUserLocationInKm < distanceThreshold) {
                recommendationResults.Add(r);
            }
        }

        return recommendationResults;
                             
    }

}