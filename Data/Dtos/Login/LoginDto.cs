using System.ComponentModel.DataAnnotations;

namespace Web_API.Data.Dtos.Login
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

}
