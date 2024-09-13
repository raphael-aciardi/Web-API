using System.ComponentModel.DataAnnotations;

namespace Web_API.Data.Dtos.Filme
{
    public class ReadFilmeDto
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public string Caminho { get; set; }
        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;

    }
}
