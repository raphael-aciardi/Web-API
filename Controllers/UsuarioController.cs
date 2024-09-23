using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API.Data;
using Web_API.Data.Dtos.Filme;
using Web_API.Data.Dtos.Usuario;
using Web_API.Models;

namespace Web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper;

    public UsuarioController (FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CadastroUsuario([FromBody] CreateUsuarioDto usuarioDto)
    {
        Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaUsuarioPorId),
            new { id = usuario.Id },
            usuario);

    }

    [HttpGet("{id}")]
    public IActionResult RecuperaUsuarioPorId(int id)
    {
        var usuario = _context.Usuarios
            .FirstOrDefault(usuario => usuario.Id == id);
        if (usuario == null) return NotFound();
        var usuarioDto = _mapper.Map<ReadUsuarioDto>(usuario);
        return Ok(usuarioDto);
    }



}
