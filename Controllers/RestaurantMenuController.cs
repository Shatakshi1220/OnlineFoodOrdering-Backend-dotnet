using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineFoodService_WebApi.Data;

namespace OnlineFoodService_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantMenuController : ControllerBase
    {
        private readonly AppDbContext db;

        public RestaurantMenuController(AppDbContext context)
        {
            db = context;

        }

        [HttpGet]
        //[Authorize]
        public IActionResult Get()
        {
            var data = db.RestaurantMenuItem.FromSqlInterpolated($"SP_RestaurantMenu");
            if (data == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(data);
            }
        }
    }
}
