using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AskToniApi.Models;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace AskToniApi.Controllers
{
    [Route("api/[controller]")]
    public class VisitController : Controller
    {
        private readonly IVisitRepository _visitRepository;
        public VisitController(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        [HttpGet]
        public Task<IEnumerable<Visit>> Get(int pageOffset = 0, int pageLimit = 0, string restaurantMongoId = null)
        {
            return GetVisits(pageOffset, pageLimit, restaurantMongoId);
        }

        private async Task<IEnumerable<Visit>> GetVisits(int pageOffset, int pageLimit, string restaurantMongoId)
        {
            if (String.IsNullOrEmpty(restaurantMongoId) == false)
            {
                if (pageLimit > 0)
                {
                    return await _visitRepository.GetAllVisitsToARestaurant(restaurantMongoId, pageOffset, pageLimit);
                }
                else
                {
                    return await _visitRepository.GetAllVisitsToARestaurant(restaurantMongoId);
                }
            }
            else
            {
                if (pageLimit > 0)
                {
                    return await _visitRepository.GetVisitsUsingFilter(pageOffset, pageLimit);
                }
                else
                {
                    return await _visitRepository.GetAllVisits();
                }
            }

        }

        // GET api/visit/ObjectId
        [HttpGet("{id}")]
        public Task<Visit> Get(string id)
        {
            return GetVisitByIdInternal(id);
        }

        private async Task<Visit> GetVisitByIdInternal(string id)
        {
            return await _visitRepository.GetVisit(id) ?? new Visit();
        }

        // POST api/visit
        [HttpPost]
        public void Post([FromBody]Visit value)
        {
            _visitRepository.AddVisit(new Visit() 
                                    { RestaurantMongoId = value.RestaurantMongoId,
                                    RestaurantYelpId = value.RestaurantYelpId, 
                                    VisitDate = value.VisitDate});
        }

        // PUT api/visit/ObjectId
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Visit value)
        {
            _visitRepository.UpdateVisit(id, value);
        }

        // DELETE api/visit/ObjectId
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _visitRepository.RemoveVisit(id);
        }       
    }
}