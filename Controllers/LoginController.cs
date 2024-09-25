using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API.Data;
using Web_API.Data.Dtos.Login;
using Web_API.Models;
namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;


        public LoginController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDto loginDto )
        {
    

            // Busca o usuário pelo email
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == loginDto.Email && u.Senha == loginDto.Password);

            // Verifica se o usuário foi encontrado e se a senha está correta
            if (usuario == null || usuario.Senha != loginDto.Password)
            {
                return Unauthorized(new { message = "Email ou senha inválidos" });
            }

            // Se as credenciais forem válidas, retorna uma resposta de sucesso
            return Ok(new { message = "Login realizado com sucesso", user = usuario });
        }
    }
}
