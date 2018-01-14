using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AskToniApi.Models;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace AskToniApi.Controllers
{
    [Route("api/[controller]")]
    public class UserVisitController : Controller
    {
        private readonly IRecommendationRepository _recommendationRepository;
        public UserVisitController(IRecommendationRepository recommendationRepository)
        {
            _recommendationRepository = recommendationRepository;
        }

        [HttpGet]
        public Task<IEnumerable<UserVisit>> Get()
        {
            return GetUserVisits();
        }

        private async Task<IEnumerable<UserVisit>> GetUserVisits()
        {
            return await _recommendationRepository.GetAllUserVisits();
        }

        // GET api/UserVisit/ObjectId
        [HttpGet("{id}")]
        public Task<UserVisit> Get(string id)
        {
            return GetUserVisitByIdInternal(id);
        }

        private async Task<UserVisit> GetUserVisitByIdInternal(string id)
        {
            return await _recommendationRepository.GetUserVisit(id) ?? new UserVisit();
        }

        // POST api/UserVisit
        [HttpPost]
        public void Post([FromBody]UserVisit value)
        {
            _recommendationRepository.AddUserVisit(new UserVisit() 
                                    { 
                                        RestaurantID = value.RestaurantID,
                                        UserProfileID = value.UserProfileID,
                                        TimeOfVisit = value.TimeOfVisit
                                    });
        }

        // PUT api/UserVisit/ObjectId
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]UserVisit value)
        {
            _recommendationRepository.UpdateUserVisit(id, value);
        }

        // DELETE api/UserVisit/ObjectId
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _recommendationRepository.RemoveUserVisit(id);
        }       
    }
}