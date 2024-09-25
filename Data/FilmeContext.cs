using Microsoft.EntityFrameworkCore;
using Web_API.Models;

namespace Web_API.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts) { }
        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<FilmeFavorito> FilmesFavoritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmeFavorito>()
                .HasKey(ff => new { ff.UsuarioId, ff.FilmeId });

            modelBuilder.Entity<FilmeFavorito>()
                .HasOne(ff => ff.Usuario)
                .WithMany(u => u.FilmesFavoritos)
                .HasForeignKey(ff => ff.UsuarioId);

            modelBuilder.Entity<FilmeFavorito>()
                .HasOne(ff => ff.Filme)
                .WithMany(f => f.FilmesFavoritos)
                .HasForeignKey(ff => ff.FilmeId);
        }
    }
}
