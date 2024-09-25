using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API.Data;
using Web_API.Data.Dtos.Login;
using Web_API.Services;
namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;
        private readonly ILoginService _userService;

        public LoginController(FilmeContext context, IMapper mapper, ILoginService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;  // Injeção de dependência para o serviço de autenticação
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            // Verifica se os dados de entrada (DTO) são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Chama o serviço de autenticação
            var user = _userService.Authenticate(loginDto.Email, loginDto.Password);

            // Retorna "Unauthorized" se o usuário não for encontrado
            if (user == null)
                return Unauthorized(new { message = "Email ou senha inválidos" });

            // Se as credenciais forem válidas, retorna uma resposta de sucesso
            return Ok(new { message = "Login realizado com sucesso", user });
        }
    }
}
