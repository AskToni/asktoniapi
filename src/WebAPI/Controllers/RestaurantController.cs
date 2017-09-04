using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AskToniApi.Models;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace AskToniApi.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        private readonly IRecommendationRepository _recommendationRepository;
        public RestaurantController(IRecommendationRepository recommendationRepository)
        {
            _recommendationRepository = recommendationRepository;
        }

        [HttpGet]
        public Task<IEnumerable<Restaurant>> Get()
        {
            return GetRestaurants();
        }

        private async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            return await _recommendationRepository.GetAllRestaurants();
        }

        // GET api/restaurant/ObjectId
        [HttpGet("{id}")]
        public Task<Restaurant> Get(string id)
        {
            return GetRestaurantByIdInternal(id);
        }

        private async Task<Restaurant> GetRestaurantByIdInternal(string id)
        {
            return await _recommendationRepository.GetRestaurant(id) ?? new Restaurant();
        }

        // POST api/restaurant
        [HttpPost]
        public void Post([FromBody]Restaurant value)
        {
            _recommendationRepository.AddRestaurant(new Restaurant() 
                                    { RestaurantName = value.RestaurantName,
                                    RestaurantId = value.RestaurantId, 
                                    ReviewCount = value.ReviewCount, 
                                    Rating = value.Rating, 
                                    Price = value.Price,
                                    Address = value.Address,
                                    City = value.City,
                                    ZipCode = value.ZipCode,
                                    Phone = value.Phone,
                                    Categories = value.Categories,
                                    ReviewIDs = value.ReviewIDs});
        }

        // PUT api/restaurant/ObjectId
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Restaurant value)
        {
            _recommendationRepository.UpdateRestaurant(id, value);
        }

        // DELETE api/restaurant/ObjectId
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _recommendationRepository.RemoveRestaurant(id);
        }       
    }
}