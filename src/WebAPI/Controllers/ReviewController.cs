using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AskToniApi.Models;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace AskToniApi.Controllers
{
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        private readonly IRecommendationRepository _recommendationRepository;
        public ReviewController(IRecommendationRepository recommendationRepository)
        {
            _recommendationRepository = recommendationRepository;
        }

        [HttpGet]
        public Task<IEnumerable<Review>> Get()
        {
            return GetReviews();
        }

        private async Task<IEnumerable<Review>> GetReviews()
        {
            return await _recommendationRepository.GetAllReviews();
        }

        // GET api/review/ObjectId
        [HttpGet("{id}")]
        public Task<Review> Get(string id)
        {
            return GetReviewByIdInternal(id);
        }

        private async Task<Review> GetReviewByIdInternal(string id)
        {
            return await _recommendationRepository.GetReview(id) ?? new Review();
        }

        // POST api/review
        [HttpPost]
        public void Post([FromBody]Review value)
        {
            _recommendationRepository.AddReview(new Review() 
                                    { RestaurantName = value.RestaurantName, 
                                    RestaurantId = value.RestaurantId, 
                                    Text = value.Text,
                                    Rating = value.Rating,
                                    UserId = value.UserId});
        }

        // PUT api/review/ObjectId
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Review value)
        {
            _recommendationRepository.UpdateReview(id, value);
        }

        // DELETE api/review/ObjectId
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _recommendationRepository.RemoveReview(id);
        }       
    }
}