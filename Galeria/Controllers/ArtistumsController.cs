using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Galeria.Models;

namespace Galeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistumsController : ControllerBase
    {
        private readonly GaleriaContext _context;

        public ArtistumsController(GaleriaContext context)
        {
            _context = context;
        }

        // GET: api/Artistums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artistum>>> GetArtista()
        {
          if (_context.Artista == null)
          {
              return NotFound();
          }
            return await _context.Artista.ToListAsync();
        }

        // GET: api/Artistums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artistum>> GetArtistum(int id)
        {
          if (_context.Artista == null)
          {
              return NotFound();
          }
            var artistum = await _context.Artista.FindAsync(id);

            if (artistum == null)
            {
                return NotFound();
            }

            return artistum;
        }

        // PUT: api/Artistums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtistum(int id, Artistum artistum)
        {
            if (id != artistum.IdArtista)
            {
                return BadRequest();
            }

            _context.Entry(artistum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Artistums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artistum>> PostArtistum(Artistum artistum)
        {
          if (_context.Artista == null)
          {
              return Problem("Entity set 'GaleriaContext.Artista'  is null.");
          }
            _context.Artista.Add(artistum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtistum", new { id = artistum.IdArtista }, artistum);
        }

        // DELETE: api/Artistums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtistum(int id)
        {
            if (_context.Artista == null)
            {
                return NotFound();
            }
            var artistum = await _context.Artista.FindAsync(id);
            if (artistum == null)
            {
                return NotFound();
            }

            _context.Artista.Remove(artistum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtistumExists(int id)
        {
            return (_context.Artista?.Any(e => e.IdArtista == id)).GetValueOrDefault();
        }
    }
}
