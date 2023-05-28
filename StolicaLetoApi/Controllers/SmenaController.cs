using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StolicaLetoApi.Models;

namespace StolicaLetoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmenaController : ControllerBase
    {
        private readonly GovnoDbContext _context;

        public SmenaController(GovnoDbContext context)
        {
            _context = context;
        }

        // GET: api/Smena
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Smena>>> GetSmenas()
        {
          if (_context.Smenas == null)
          {
              return NotFound();
          }
            return await _context.Smenas.ToListAsync();
        }

        // GET: api/Smena/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Smena>> GetSmena(int id)
        {
          if (_context.Smenas == null)
          {
              return NotFound();
          }
            var smena = await _context.Smenas.FindAsync(id);

            if (smena == null)
            {
                return NotFound();
            }

            return smena;
        }

        // PUT: api/Smena/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmena(int id, Smena smena)
        {
            if (id != smena.Id)
            {
                return BadRequest();
            }

            _context.Entry(smena).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmenaExists(id))
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

        // POST: api/Smena
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Smena>> PostSmena(Smena smena)
        {
          if (_context.Smenas == null)
          {
              return Problem("Entity set 'GovnoDbContext.Smenas'  is null.");
          }
            _context.Smenas.Add(smena);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmena", new { id = smena.Id }, smena);
        }

        // DELETE: api/Smena/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmena(int id)
        {
            if (_context.Smenas == null)
            {
                return NotFound();
            }
            var smena = await _context.Smenas.FindAsync(id);
            if (smena == null)
            {
                return NotFound();
            }

            _context.Smenas.Remove(smena);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SmenaExists(int id)
        {
            return (_context.Smenas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
