using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineFoodService_WebApi.Data;
using OnlineFoodService_WebApi.Model;
using OnlineFoodService_WebApi.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineFoodService_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthenticateController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        [HttpPost]
        [Route("Login")]

        public ActionResult<dynamic> Login(UserLogin model)
        {
            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                var user = _context.Users.SingleOrDefault(s => s.Email == model.Email && s.Password == model.Password);
                if (user != null)
                {
                    var token = GenerateToken(user);
                    return Ok(new { user.Email, user.UserName, Token = token });
                }
                else
                {
                    return Unauthorized("Wrong Credentials Try again!");
                }

            }
            else
            {
                return BadRequest();
            }
        }
        [NonAction]

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Jwt:secret")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                       issuer: _config.GetValue<string>("Jwt:issuer"),
                       audience: _config.GetValue<string>("Jwt:audience"),
                       claims: claims,
                       expires: DateTime.Now.AddMinutes(30),
                       signingCredentials: credentials);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
