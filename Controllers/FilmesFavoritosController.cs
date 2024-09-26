using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.Data;
using Web_API.Models;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmesFavoritosController : ControllerBase
    {
        private readonly FilmeContext _context;

        public FilmesFavoritosController(FilmeContext context)
        {
            _context = context;
        }

        // Rota para adicionar filme favorito
        [HttpPost("add")]
        public async Task<IActionResult> AddFilmeFavorito(int usuarioId, int filmeId)
        {
            var usuario = await _context.Usuarios.FindAsync(usuarioId);
            var filme = await _context.Filmes.FindAsync(filmeId);

            if (usuario == null || filme == null)
            {
                return NotFound("Usuário ou Filme não encontrado");
            }

            // Verifica se já existe essa combinação na tabela FilmeFavorito
            var filmeFavoritoExistente = await _context.FilmesFavoritos
                .FirstOrDefaultAsync(ff => ff.UsuarioId == usuarioId && ff.FilmeId == filmeId);

            if (filmeFavoritoExistente != null)
            {
                return Conflict("Esse filme já está nos favoritos do usuário.");
            }

            var filmeFavorito = new FilmeFavorito
            {
                UsuarioId = usuarioId,
                FilmeId = filmeId
            };

            _context.FilmesFavoritos.Add(filmeFavorito);
            await _context.SaveChangesAsync();

            return Ok("Filme adicionado aos favoritos com sucesso.");
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetFilmesFavoritos(int usuarioId)
        {
            // Busca os filmes favoritos do usuário específico
            var filmesFavoritos = await _context.FilmesFavoritos
                .Where(ff => ff.UsuarioId == usuarioId)
                .Include(ff => ff.Filme) // Inclui detalhes do filme
                .ToListAsync();

            if (filmesFavoritos == null || !filmesFavoritos.Any())
            {
                return NotFound("Nenhum filme favorito encontrado para este usuário.");
            }

            // Retorna os detalhes dos filmes favoritos
            var resultado = filmesFavoritos.Select(ff => new
            {
                ff.FilmeId,
                ff.Filme.Titulo,
                ff.Filme.Genero,
                ff.Filme.Duracao,
                ff.Filme.Caminho
                
           // Supondo que a entidade Filme tem uma propriedade Titulo
                                  // Adicione outras propriedades que deseja retornar
            }).ToList();

            return Ok(resultado);
        }
    }



}
