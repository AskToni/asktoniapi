using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AskToniApi.Models;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace AskToniApi.Controllers
{
    [Route("api/[controller]")]
    public class RecommendationController : Controller
    {
        private readonly IRecommendationRepository _recommendationRepository;
        public RecommendationController(IRecommendationRepository recommendationRepository)
        {
            _recommendationRepository = recommendationRepository;
        }

        [HttpGet]
        public Task<IEnumerable<Restaurant>> Get(double latitude, double longitude, string category, int pageOffset, int pageLimit, int sort = 1)
        {
            return GetRecommendations(latitude, longitude, category, pageOffset, pageLimit, sort);
        }

        private async Task<IEnumerable<Restaurant>> GetRecommendations(double latitude, double longitude, string category, int pageOffset, int pageLimit, int sort)
        {
            return await _recommendationRepository.GetRecommendations(latitude, longitude, category, pageOffset, pageLimit, sort);
        }

        [HttpGet("/api/Recommendation/categories")]
        public Task<IEnumerable<string>> GetCategories()
        {
            return GetRecommendationCategories();
        }

        private async Task<IEnumerable<string>> GetRecommendationCategories()
        {
            return await _recommendationRepository.GetRecommendationCategories();
        }
    }
}