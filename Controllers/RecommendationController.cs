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
        public Task<IEnumerable<Recommendation>> Get()
        {
            return GetRecommendationInternal();
        }

        private async Task<IEnumerable<Recommendation>> GetRecommendationInternal()
        {
            return await _recommendationRepository.GetAllRecommendations();
        }

        // GET api/recommendation/5
        [HttpGet("{id}")]
        public Task<Recommendation> Get(string id)
        {
            return GetRecommendationByIdInternal(id);
        }

        private async Task<Recommendation> GetRecommendationByIdInternal(string id)
        {
            return await _recommendationRepository.GetRecommendation(id) ?? new Recommendation();
        }

        // POST api/recommendation
        [HttpPost]
        public void Post([FromBody]Recommendation value)
        {
            _recommendationRepository.AddRecommendation(new Recommendation() 
                                    { RestaurantName = value.RestaurantName, 
                                    Website = value.Website, 
                                    Address = value.Address });
        }

        // PUT api/recommendation/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Recommendation value)
        {
            _recommendationRepository.UpdateRecommendation(id, value);
        }

        // DELETE api/recommendation/5
        public void Delete(string id)
        {
            _recommendationRepository.RemoveRecommendation(id);
        }       
    }
}