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
    public class CuadroesController : ControllerBase
    {
        private readonly GaleriaContext _context;

        public CuadroesController(GaleriaContext context)
        {
            _context = context;
        }

        // GET: api/Cuadroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuadro>>> GetCuadros()
        {
          if (_context.Cuadros == null)
          {
              return NotFound();
          }
            return await _context.Cuadros.ToListAsync();
        }

        // GET: api/Cuadroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuadro>> GetCuadro(int id)
        {
          if (_context.Cuadros == null)
          {
              return NotFound();
          }
            var cuadro = await _context.Cuadros.FindAsync(id);

            if (cuadro == null)
            {
                return NotFound();
            }

            return cuadro;
        }

        // PUT: api/Cuadroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuadro(int id, Cuadro cuadro)
        {
            if (id != cuadro.IdCuadro)
            {
                return BadRequest();
            }

            _context.Entry(cuadro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuadroExists(id))
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

        // POST: api/Cuadroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cuadro>> PostCuadro(Cuadro cuadro)
        {
          if (_context.Cuadros == null)
          {
              return Problem("Entity set 'GaleriaContext.Cuadros'  is null.");
          }
            _context.Cuadros.Add(cuadro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuadro", new { id = cuadro.IdCuadro }, cuadro);
        }

        // DELETE: api/Cuadroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuadro(int id)
        {
            if (_context.Cuadros == null)
            {
                return NotFound();
            }
            var cuadro = await _context.Cuadros.FindAsync(id);
            if (cuadro == null)
            {
                return NotFound();
            }

            _context.Cuadros.Remove(cuadro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuadroExists(int id)
        {
            return (_context.Cuadros?.Any(e => e.IdCuadro == id)).GetValueOrDefault();
        }
    }
}
