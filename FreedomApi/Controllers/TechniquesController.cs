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
    public class TechniquesController : ControllerBase
    {
        private readonly FreedomContext _context;

        public TechniquesController(FreedomContext context)
        {
            _context = context;
        }

        // GET: api/Techniques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Techniques>>> GetTechniques()
        {
            var techniquesList = await _context.Techniques.ToListAsync();

            techniquesList.ForEach(async t => t.Skills = await _context.Skills.FindAsync(t.SkillId));
            return techniquesList;
        }

        // GET: api/Techniques/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Techniques>> GetTechniques(int id)
        {
            var techniques = await _context.Techniques.FindAsync(id);

            if (techniques == null)
            {
                return NotFound();
            }

            techniques.Skills = await _context.Skills.FindAsync(techniques.SkillId);

            return techniques;
        }

        // PUT: api/Techniques/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechniques(int id, Techniques techniques)
        {
            if (id != techniques.Id)
            {
                return BadRequest();
            }

            _context.Entry(techniques).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechniquesExists(id))
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

        // POST: api/Techniques
        [HttpPost]
        public async Task<ActionResult<Techniques>> PostTechniques(Techniques techniques)
        {
            _context.Techniques.Add(techniques);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TechniquesExists(techniques.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTechniques", new { id = techniques.Id }, techniques);
        }

        // DELETE: api/Techniques/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Techniques>> DeleteTechniques(int id)
        {
            var techniques = await _context.Techniques.FindAsync(id);
            if (techniques == null)
            {
                return NotFound();
            }

            _context.Techniques.Remove(techniques);
            await _context.SaveChangesAsync();

            return techniques;
        }

        private bool TechniquesExists(int id)
        {
            return _context.Techniques.Any(e => e.Id == id);
        }
    }
}
