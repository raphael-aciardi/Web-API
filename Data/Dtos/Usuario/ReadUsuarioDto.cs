using System.ComponentModel.DataAnnotations;

namespace Web_API.Data.Dtos.Usuario
{
    public class ReadUsuarioDto
    {

        [Required]
        public string Login { get; set; }


        [Required]
        public string Email { get; set; }
    }
}
