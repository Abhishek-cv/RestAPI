using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmplolyeesController : ControllerBase
    {
        private readonly APIdbcontext _context;

        public EmplolyeesController(APIdbcontext context)
        {
            _context = context;
        }

        // GET: api/Emplolyees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emplolyee>>> GetEmplolyee()
        {
          if (_context.Emplolyee == null)
          {
              return NotFound();
          }
            return await _context.Emplolyee.ToListAsync();
        }

        // GET: api/Emplolyees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emplolyee>> GetEmplolyee(int id)
        {
          if (_context.Emplolyee == null)
          {
              return NotFound();
          }
            var emplolyee = await _context.Emplolyee.FindAsync(id);

            if (emplolyee == null)
            {
                return NotFound();
            }

            return emplolyee;
        }

        // PUT: api/Emplolyees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmplolyee(int id, Emplolyee emplolyee)
        {
            if (id != emplolyee.Id)
            {
                return BadRequest();
            }

            _context.Entry(emplolyee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmplolyeeExists(id))
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

        // POST: api/Emplolyees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Emplolyee>> PostEmplolyee(Emplolyee emplolyee)
        {
          if (_context.Emplolyee == null)
          {
              return Problem("Entity set 'APIdbcontext.Emplolyee'  is null.");
          }
            _context.Emplolyee.Add(emplolyee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmplolyee", new { id = emplolyee.Id }, emplolyee);
        }

        // DELETE: api/Emplolyees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmplolyee(int id)
        {
            if (_context.Emplolyee == null)
            {
                return NotFound();
            }
            var emplolyee = await _context.Emplolyee.FindAsync(id);
            if (emplolyee == null)
            {
                return NotFound();
            }

            _context.Emplolyee.Remove(emplolyee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmplolyeeExists(int id)
        {
            return (_context.Emplolyee?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
