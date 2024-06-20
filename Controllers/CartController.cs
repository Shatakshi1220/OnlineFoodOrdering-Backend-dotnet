using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodService_WebApi.Data;
using OnlineFoodService_WebApi.Model;

namespace OnlineFoodService_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Get() 
        {
            return Ok(_context.Cart);
        
        }

        [HttpPost]

        public IActionResult Post(Cart newItem)
        {
            _context.Cart.Add(newItem);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            
          
             var item = _context.Cart.FirstOrDefault(c=>c.cartId== id);
             if (item == null)
            {
                 return NotFound();
             }
             _context.Cart.Remove(item);
            _context.SaveChanges();
            return Ok(); // Return 200 OK if deletion is successful
        }


    }
}
