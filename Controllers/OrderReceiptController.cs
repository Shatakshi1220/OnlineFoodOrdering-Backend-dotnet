using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineFoodService_WebApi.Data;

namespace OnlineFoodService_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderReceiptController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderReceiptController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orderReceipt = _context.OrderReceipt.FromSqlInterpolated($"SP_Order_Receipt");
            if ( orderReceipt == null ) { 
            return NotFound();
            }
            else
            {
                return Ok( orderReceipt );
            }
            
        }
    }
}
