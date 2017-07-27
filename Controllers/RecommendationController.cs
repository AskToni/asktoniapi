using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AskToniApi.Models;
using System.Linq;

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
                _context.Recommendations.Add(new Recommendation { RestaurantName = "Thai Express", Website = "https://thaiexpress.ca", Address = "4820 Kingsway, Suite 318" });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<Recommendation> GetAll()
        {
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
    }
}