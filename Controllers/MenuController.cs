using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodService_WebApi.Data;
using OnlineFoodService_WebApi.Model;

namespace OnlineFoodService_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult GetMenu()
        {
            var menu= _context.MenuItems.ToList();
            if (menu != null)
            {
                return Ok(_context.MenuItems);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet ("GetMenusByRestaurant/{id}")]
        
        public IActionResult GetMenus(int id)
        {
            var menu = _context.MenuItems.Where(s=>s.RestaurantId==id);
            if (menu != null)
            {
                return Ok(menu);
            }
            else
            {
                return NotFound("Invalid Restaurant Id");
            }
        }

        [HttpPost]

        public IActionResult PostMenu(MenuItem newMenu)
        {
            if (newMenu == null)
            {
                return BadRequest();
            }
            else
            {
                _context.MenuItems.Add(newMenu);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
