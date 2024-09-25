using System.ComponentModel.DataAnnotations;

namespace Web_API.Models
{
    public class Login
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
