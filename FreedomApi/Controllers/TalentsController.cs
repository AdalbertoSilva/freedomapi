using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreedomApi.Data;
using FreedomApi.Models;

namespace FreedomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalentsController : ControllerBase
    {
        private readonly FreedomContext _context;

        public TalentsController(FreedomContext context)
        {
            _context = context;
        }

        // GET: api/Talents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Talent>>> GetTalent()
        {
            return await _context.Talent.ToListAsync();
        }

        // GET: api/Talents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Talent>> GetTalent(int id)
        {
            var talent = await _context.Talent.FindAsync(id);

            if (talent == null)
            {
                return NotFound();
            }

            return talent;
        }

        // PUT: api/Talents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTalent(int id, Talent talent)
        {
            if (id != talent.Id)
            {
                return BadRequest();
            }

            _context.Entry(talent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TalentExists(id))
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

        // POST: api/Talents
        [HttpPost]
        public async Task<ActionResult<Talent>> PostTalent(Talent talent)
        {
            _context.Talent.Add(talent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TalentExists(talent.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTalent", new { id = talent.Id }, talent);
        }

        // DELETE: api/Talents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Talent>> DeleteTalent(int id)
        {
            var talent = await _context.Talent.FindAsync(id);
            if (talent == null)
            {
                return NotFound();
            }

            _context.Talent.Remove(talent);
            await _context.SaveChangesAsync();

            return talent;
        }

        private bool TalentExists(int id)
        {
            return _context.Talent.Any(e => e.Id == id);
        }
    }
}
