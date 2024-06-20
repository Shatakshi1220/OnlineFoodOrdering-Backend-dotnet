using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodService_WebApi.Data;
using OnlineFoodService_WebApi.Model;

namespace OnlineFoodService_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ALoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ALoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        
        public IActionResult Post([FromBody] AdminLogin model)
        {
            var admin = _context.AdminLogin.FirstOrDefault(p => p.Email == model.Email && p.Password == model.Password);
            if(admin == null)
            {
                return NotFound("No match");
            }
            else
            {
                return Ok(admin);
            }


        }
    }
}
