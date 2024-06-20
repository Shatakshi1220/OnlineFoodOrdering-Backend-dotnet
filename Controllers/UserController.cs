using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodService_WebApi.Data;
using OnlineFoodService_WebApi.Model;

namespace OnlineFoodService_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var data = _context.Users.ToList();
            if(data!=null)
            {
                return Ok(data);
            }
            else
            {
               return BadRequest("No Records Found");
            }
           
        }

        [HttpPost]
        [Route("Register")]

        public IActionResult Post(User newUser)
        {
            if (newUser == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return Ok();
            }

        }
    }
}
