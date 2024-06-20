using System.ComponentModel.DataAnnotations;

namespace OnlineFoodService_WebApi.Model
{
    public class AdminLogin
    {
        [Key]
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
