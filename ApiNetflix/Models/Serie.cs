namespace ApiMovies.Models
{

    //Definindo o Modelo de Dados
    public class Serie
{
        public int SerieId { get; set; }
        public string? Titulo { get; set; }
        public int Ano { get; set; }
        public double Nota { get; set; }
        public int Temporadas { get; set; }
        public string? Genero { get; set; }
        public string? Pais { get; set; }
    }
}
