using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AskToniApi.Models;
using System.Linq;
using System;

namespace AskToniApi.Controllers
{
    [Route("api/[controller]")]
    public class RecommendationController : Controller
    {
        private readonly AskToniContext _context;

        public RecommendationController(AskToniContext context)
        {
            _context = context;

            if (_context.Recommendations.Count() == 0)
            {
                _context.Recommendations.Add(new Recommendation { RestaurantName = "Thai Express", Website = "https://www.thaiexpress.ca", Address = "4820 Kingsway, Suite 318" });
                _context.Recommendations.Add(new Recommendation { RestaurantName = "Bubble Waffle", Website = "https://www.bubblewafflecafe.ca", Address = "4500 Kingsway" });
                _context.Recommendations.Add(new Recommendation { RestaurantName = "Boiling Point", Website = "https://www.bpgroupusa.com/", Address = "5276 Kingsway" });
                _context.Recommendations.Add(new Recommendation { RestaurantName = "Curry Express", Website = "https://curry-express.ca/", Address = "4820 Kingsway" });
                _context.Recommendations.Add(new Recommendation { RestaurantName = "The Boss Bakery & Restaurant", Address = "4800 Kingsway" });
                _context.Recommendations.Add(new Recommendation { RestaurantName = "Satomi Sushi", Address = "4689 Kingsway" });
                _context.Recommendations.Add(new Recommendation { RestaurantName = "Daeji Cutlet House", Website = "https://www.daejifood.com", Address = "4883 Kingsway" });
                _context.Recommendations.Add(new Recommendation { RestaurantName = "Saffron", Website = "http://www.saffroncuisine.ca/", Address = "4300 Kingsway" });

                _context.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<Recommendation> GetRecomendation()
        {
            // Return random restaurant recommendation
            return _context.Recommendations.OrderBy(x => Guid.NewGuid()).Take(1);
        }

        [HttpGet("/api/[controller]/GetAll")]
        public IEnumerable<Recommendation> GetAllRecomendations()
        {
            // Return all recommendations
            return _context.Recommendations.ToList();
        }

        [HttpGet("{id}", Name = "GetRecommendation")]
        public IActionResult GetById(long id)
        {
            var item = _context.Recommendations.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Recommendation item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Recommendations.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetRecomendation", new { id = item.Id }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Recommendation item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var recommendation = _context.Recommendations.FirstOrDefault(t => t.Id == id);
            if (recommendation == null)
            {
                return NotFound();
            }

            recommendation.RestaurantName = item.RestaurantName;
            recommendation.Address = item.Address;
            recommendation.Website = item.Website;

            _context.Recommendations.Update(recommendation);
            _context.SaveChanges();
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var recommendation = _context.Recommendations.First(t => t.Id == id);
            if (recommendation == null)
            {
                return NotFound();
            }

            _context.Recommendations.Remove(recommendation);
            _context.SaveChanges();
            return new NoContentResult();
        }       
    }
}