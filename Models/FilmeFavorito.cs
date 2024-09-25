namespace Web_API.Models
{
    public class FilmeFavorito
    {
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int FilmeId { get; set; }
        public virtual Filme Filme { get; set; }

        

    }
}
