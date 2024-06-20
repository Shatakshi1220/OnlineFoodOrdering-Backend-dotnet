using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodService_WebApi.Data;
using OnlineFoodService_WebApi.Model;

namespace OnlineFoodService_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RestaurantController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetResTaurantsList()
        {
            var rest=_context.Restaurants.ToList();
            if (rest != null)
            {
                return Ok(_context.Restaurants);
            }
            else
            {
                return BadRequest("No Records Found");
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetRestaurants(int id) {

            var rest=_context.Restaurants.FirstOrDefault(s=>s.RestaurantId==id);
            if(rest != null)
            {
                return Ok(rest);
            }
            else
            {
                return NotFound("No match found");
            }
        }


        [HttpPost]
        public IActionResult PostRestaurant(Restaurant rest)
        {
            if (rest == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Restaurants.Add(rest);
                _context.SaveChanges();
                return Ok(rest);
            }

        }
    }
}
