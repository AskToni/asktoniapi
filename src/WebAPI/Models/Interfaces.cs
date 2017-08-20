using System.Threading.Tasks;
using AskToniApi.Models;
using System.Collections.Generic;
using MongoDB.Driver;

public interface IRecommendationRepository
{
    Task<IEnumerable<Restaurant>> GetAllRestaurants();
    Task<Restaurant> GetRestaurant(string id);
    Task AddRestaurant(Restaurant item);
    Task<DeleteResult> RemoveRestaurant(string id);
    Task<ReplaceOneResult> UpdateRestaurant(string id, Restaurant item);
}