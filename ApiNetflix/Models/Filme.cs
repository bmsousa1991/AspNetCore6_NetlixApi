namespace ApiMovies.Models
{

    public class Filme
    {
        public int FilmeId { get; set; }
        public string? Titulo { get; set; }
        public int Ano { get; set; }
        public double Nota { get; set; }
        public string? Genero { get; set; }
        public string? Pais { get; set;}
    }
}
