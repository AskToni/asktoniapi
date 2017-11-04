using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AskToniApi.Models;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace AskToniApi.Controllers
{
    [Route("api/[controller]")]
    public class RecomendationController : Controller
    {
        private readonly IRecommendationRepository _recommendationRepository;
        public RecomendationController(IRecommendationRepository recommendationRepository)
        {
            _recommendationRepository = recommendationRepository;
        }

        [HttpGet]
        public Task<IEnumerable<Restaurant>> Get(double latitude, double longitude, string category)
        {
            return GetRecommendation(latitude, longitude, category);
        }

        private async Task<IEnumerable<Restaurant>> GetRecommendation(double latitude, double longitude, string category)
        {
            return await _recommendationRepository.GetRecommendation(latitude, longitude, category);
        }

    }
}