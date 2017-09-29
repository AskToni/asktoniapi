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

}

public interface IVisitRepository
{
    Task<IEnumerable<Visit>> GetAllVisitsToARestaurant(string restaurantMongoId, int pageOffset, int pageLimit);

    Task<IEnumerable<Visit>> GetAllVisitsToARestaurant(string restaurantMongoId);

    Task<IEnumerable<Visit>> GetAllVisits();

    Task<IEnumerable<Visit>> GetVisitsUsingFilter(int pageOffset, int pageLimit);

    Task<Visit> GetVisit(string id);

    Task AddVisit(Visit item);

    Task<DeleteResult> RemoveVisit(string id);

    Task<ReplaceOneResult> UpdateVisit(string id, Visit item);

    Task AddUserToVisit(string userId, string visitId);
}

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsers();

    Task AddUser(User item);
}