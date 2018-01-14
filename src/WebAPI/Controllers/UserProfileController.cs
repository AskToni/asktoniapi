using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AskToniApi.Models;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace AskToniApi.Controllers
{
    [Route("api/[controller]")]
    public class UserProfileController : Controller
    {
        private readonly IRecommendationRepository _recommendationRepository;
        public UserProfileController(IRecommendationRepository recommendationRepository)
        {
            _recommendationRepository = recommendationRepository;
        }

        [HttpGet]
        public Task<IEnumerable<UserProfile>> Get()
        {
            return GetUserProfiles();
        }

        private async Task<IEnumerable<UserProfile>> GetUserProfiles()
        {
            return await _recommendationRepository.GetAllUserProfiles();
        }

        // GET api/userprofile/ObjectId
        [HttpGet("{id}")]
        public Task<UserProfile> Get(string id)
        {
            return GetUserProfileByIdInternal(id);
        }

        private async Task<UserProfile> GetUserProfileByIdInternal(string id)
        {
            return await _recommendationRepository.GetUserProfile(id) ?? new UserProfile();
        }

        // POST api/userprofile
        [HttpPost]
        public void Post([FromBody]UserProfile value)
        {
            _recommendationRepository.AddUserProfile(new UserProfile() 
                                    { Name = value.Name,
                                      Email = value.Email,
                                      CategoryPreferences = value.CategoryPreferences,
                                      FavouriteRestaurants = value.FavouriteRestaurants
                                    });
        }

        // PUT api/userprofile/ObjectId
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]UserProfile value)
        {
            _recommendationRepository.UpdateUserProfile(id, value);
        }

        // DELETE api/userprofile/ObjectId
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _recommendationRepository.RemoveUserProfile(id);
        }       
    }
}