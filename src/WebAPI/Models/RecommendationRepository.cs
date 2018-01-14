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

    #region Restaurants

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

    #endregion

    #region Reviews

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

    #endregion Reviews

    #region Recommendations

    public async Task<IEnumerable<Restaurant>> GetRecommendations(double latitude, double longitude, string category, int pageOffset, int pageLimit, int sort)
    {
        var filter = Builders<Restaurant>.Filter.AnyEq(r => r.Categories, category);
        List<Restaurant> relatedRestaurants = null;

        if (pageOffset >= 0 && pageLimit > 0) {
            relatedRestaurants = await _context.Recommendations.Find(filter).Skip(pageOffset*pageLimit).Limit(pageLimit).Sort("{RestaurantName: " + sort + "}").ToListAsync();
        } else {
            relatedRestaurants = await _context.Recommendations.Find(filter).Sort("{RestaurantName: " + sort + "}").ToListAsync();
        }

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

    public async Task<IEnumerable<string>> GetRecommendationCategories() 
    {
        var categories = await _context.Recommendations.DistinctAsync<string>("Categories", Builders<Restaurant>.Filter.Empty);

        return categories.ToList();

    }

    #endregion Recommendations

    #region UserProfiles

    public async Task<UserProfile> GetUserProfile(string id)
    {
        var filter = Builders<UserProfile>.Filter.Eq(r => r.Id, id);
        return await _context.UserProfiles
                             .Find(filter)
                             .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<UserProfile>> GetAllUserProfiles()
    {
        try {
            return await _context.UserProfiles.Find(_ => true).ToListAsync();
        }
        catch (Exception ex) {
            throw ex;
        }
    }

    public async Task AddUserProfile(UserProfile item)
    {
        await _context.UserProfiles.InsertOneAsync(item);
    }

    public async Task<DeleteResult> RemoveUserProfile(string id)
    {
        return await _context.UserProfiles.DeleteOneAsync(
                     Builders<UserProfile>.Filter.Eq(r => r.Id, id));
    }
   
    public async Task<ReplaceOneResult> UpdateUserProfile(string id, UserProfile item)
    {
        item.Id = id;

        return await _context.UserProfiles
                             .ReplaceOneAsync(r => r.Id.Equals(ObjectId.Parse(id)),
                                             item,
                                             new UpdateOptions { IsUpsert = true });
    }

    #endregion

    #region UserVisit

    public async Task<UserVisit> GetUserVisit(string id)
    {
        var filter = Builders<UserVisit>.Filter.Eq(r => r.Id, id);
        return await _context.UserVisits
                             .Find(filter)
                             .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<UserVisit>> GetAllUserVisits()
    {
        try {
            return await _context.UserVisits.Find(_ => true).ToListAsync();
        }
        catch (Exception ex) {
            throw ex;
        }
    }

    public async Task AddUserVisit(UserVisit item)
    {
        await _context.UserVisits.InsertOneAsync(item);
    }

    public async Task<DeleteResult> RemoveUserVisit(string id)
    {
        return await _context.UserVisits.DeleteOneAsync(
                     Builders<UserVisit>.Filter.Eq(r => r.Id, id));
    }
   
    public async Task<ReplaceOneResult> UpdateUserVisit(string id, UserVisit item)
    {
        item.Id = id;

        return await _context.UserVisits
                             .ReplaceOneAsync(r => r.Id.Equals(ObjectId.Parse(id)),
                                             item,
                                             new UpdateOptions { IsUpsert = true });
    }

    #endregion

}