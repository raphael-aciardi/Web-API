using System.ComponentModel.DataAnnotations;

namespace Web_API.Data.Dtos.Usuario
{
    public class CreateUsuarioDto
    {

        [Required]
        public string Login { get; set; }


        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
