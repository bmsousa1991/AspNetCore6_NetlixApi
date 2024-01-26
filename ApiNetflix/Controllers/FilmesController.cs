using ApiMovies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ApiMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        //Injetando contexto do banco de dados no controlador

        public readonly AppDbContext _dbContext;

        public FilmesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET api/Filmes

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Filme>>> GetFilmes()
        {
            if (_dbContext.Filmes == null) { return NotFound(); }

            return await _dbContext.Filmes.ToListAsync();
        }

        //GET api/Filmes/{id}

        [HttpGet("{id}")]

        public async Task<ActionResult<Filme>> GetFilme(int id)
        {
            if ( _dbContext.Filmes == null) { return NotFound(); }

            var filme = await _dbContext.Filmes.FindAsync(id);

            if (filme == null) { return NotFound($"FilmeId {id} não encontrado."); }

            return Ok(filme);
        }

        //POST api/filmes

        [HttpPost]

        public async Task<ActionResult<Filme>> PostFilme(Filme filme)
        {
            _dbContext.Filmes.Add(filme);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFilme), new { id = filme.FilmeId }, filme);
        }

        //PUT api/filmes/{id}

        [HttpPut("{id}")]

        public async Task<ActionResult> PutFilme(int id, Filme filme)
        {
            if (id != filme.FilmeId) { return BadRequest(); }

            _dbContext.Entry(filme).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException) 
            {
                if (!FilmeExists(id)) { return NotFound(); }

                else { throw; }
            }

            return NoContent();
        }

        //DELETE api/filmes/{id}

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteFilme(int id)
        {
            if (_dbContext.Filmes == null) { return NotFound(); }

            var filme = await _dbContext.Filmes.FindAsync(id);

            if (filme == null) { return NotFound(); }

            _dbContext.Filmes.Remove(filme);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmeExists(long id)
        {
            return (_dbContext.Filmes?.Any(e => e.FilmeId == id)).GetValueOrDefault();
        }
    }
}
