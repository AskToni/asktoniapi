using System.Threading.Tasks;
using AskToniApi.Models;
using System.Collections.Generic;
using MongoDB.Driver;

public interface IRecommendationRepository
{
    Task<IEnumerable<Recommendation>> GetAllRecommendations();
    Task<Recommendation> GetRecommendation(string id);
    Task AddRecommendation(Recommendation item);
    Task<DeleteResult> RemoveRecommendation(string id);
    Task<ReplaceOneResult> UpdateRecommendation(string id, Recommendation item);

    Task<DeleteResult> RemoveAllRecommendations();
}