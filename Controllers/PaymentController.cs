using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodService_WebApi.Data;
using OnlineFoodService_WebApi.Model;

namespace OnlineFoodService_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("PaymentDetails")]

        public IActionResult Get()
        {
            var payment = _context.Payment.ToList();
            if(payment == null)
            {
                return NotFound("No Records Found");
            }
            return Ok(_context.Payment);

        }

        [HttpPost]
        
        public IActionResult Post(Payment payment)
        {
            if (payment == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Payment.Add(payment);
                _context.SaveChanges();
                return Ok();
            }

        }
    }
}
