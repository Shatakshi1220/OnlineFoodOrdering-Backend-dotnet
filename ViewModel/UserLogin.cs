using System.ComponentModel.DataAnnotations;

namespace OnlineFoodService_WebApi.ViewModel
{
    public class UserLogin
    {
        [Required]
        [MinLength(6)]
        public string? Email { get; set; }
        [Required]
        [MinLength(6)]
        public string? Password { get; set; }

    }
}
