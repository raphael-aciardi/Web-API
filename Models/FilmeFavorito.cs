namespace Web_API.Models
{
    public class FilmeFavorito
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int FilmeId { get; set; }
        public Filme Filme { get; set; }
    }
}
