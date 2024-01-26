using Microsoft.EntityFrameworkCore;

namespace ApiMovies.Models
{ 
    // Definindo DbContext
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Definindo nome da Tabela - Filmes & Series
        public DbSet<Filme>? Filmes { get; set; }

        public DbSet<Serie>? Series { get; set; }

    }
}
