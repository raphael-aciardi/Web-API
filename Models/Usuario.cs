using System.ComponentModel.DataAnnotations;

namespace Web_API.Models;

public class Usuario
{
    [Key]
    [Required]
    public  int Id { get; set; }

    [Required]
    public string Login { get; set; }


    [Required]
    public string Email { get; set; }

    [Required]
    public string Senha { get; set; }
}
