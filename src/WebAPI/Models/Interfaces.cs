using System.Threading.Tasks;
using AskToniApi.Models;
using System.Collections.Generic;
using MongoDB.Driver;

public interface IRecommendationRepository
{
    #region Restaurants
    Task<IEnumerable<Restaurant>> GetAllRestaurants();
    Task<IEnumerable<Restaurant>> GetRestaurantsUsingFilter(int pageOffset, int pageLimit);
    Task<Restaurant> GetRestaurant(string id);
    Task AddRestaurant(Restaurant item);
    Task<DeleteResult> RemoveRestaurant(string id);
    Task<ReplaceOneResult> UpdateRestaurant(string id, Restaurant item);

    #endregion

    #region Reviews

    // Reviews
    Task<IEnumerable<Review>> GetAllReviews();
    Task<Review> GetReview(string id);
    Task AddReview(Review item);
    Task<DeleteResult> RemoveReview(string id);
    Task<ReplaceOneResult> UpdateReview(string id, Review item);

    #endregion
    
    #region Recommendations
    Task<IEnumerable<Restaurant>> GetRecommendations(double latitude, double longitude, string category, int pageOffset, int pageLimit, int sort);
    Task<IEnumerable<string>> GetRecommendationCategories();

    #endregion
    
    #region UserProfiles
    
    Task<UserProfile> GetUserProfile(string id);
    Task<IEnumerable<UserProfile>> GetAllUserProfiles();
    Task AddUserProfile(UserProfile item);
    Task<DeleteResult> RemoveUserProfile(string id);
    Task<ReplaceOneResult> UpdateUserProfile(string id, UserProfile item);

    #endregion

    #region UserVisits

    Task<UserVisit> GetUserVisit(string id);
    Task<IEnumerable<UserVisit>> GetAllUserVisits();
    Task AddUserVisit(UserVisit item);
    Task<DeleteResult> RemoveUserVisit(string id);
    Task<ReplaceOneResult> UpdateUserVisit(string id, UserVisit item);

    #endregion

}