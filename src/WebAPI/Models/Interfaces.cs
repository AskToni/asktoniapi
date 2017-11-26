using System.Threading.Tasks;
using AskToniApi.Models;
using System.Collections.Generic;
using MongoDB.Driver;

public interface IRecommendationRepository
{
    // Restaurants
    Task<IEnumerable<Restaurant>> GetAllRestaurants();
    Task<IEnumerable<Restaurant>> GetRestaurantsUsingFilter(int pageOffset, int pageLimit);
    Task<Restaurant> GetRestaurant(string id);
    Task AddRestaurant(Restaurant item);
    Task<DeleteResult> RemoveRestaurant(string id);
    Task<ReplaceOneResult> UpdateRestaurant(string id, Restaurant item);

    // Reviews
    Task<IEnumerable<Review>> GetAllReviews();
    Task<Review> GetReview(string id);
    Task AddReview(Review item);
    Task<DeleteResult> RemoveReview(string id);
    Task<ReplaceOneResult> UpdateReview(string id, Review item);
    Task<IEnumerable<Restaurant>> GetRecommendations(double latitude, double longitude, string category, int pageOffset, int pageLimit, int sort);

}