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
    public class RemarkableTraitsController : ControllerBase
    {
        private readonly FreedomContext _context;

        public RemarkableTraitsController(FreedomContext context)
        {
            _context = context;
        }

        // GET: api/RemarkableTraits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RemarkableTrait>>> GetRemarkableTrait()
        {
            return await _context.RemarkableTrait.ToListAsync();
        }

        // GET: api/RemarkableTraits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RemarkableTrait>> GetRemarkableTrait(int id)
        {
            var remarkableTrait = await _context.RemarkableTrait.FindAsync(id);

            if (remarkableTrait == null)
            {
                return NotFound();
            }

            return remarkableTrait;
        }

        // PUT: api/RemarkableTraits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRemarkableTrait(int id, RemarkableTrait remarkableTrait)
        {
            if (id != remarkableTrait.Id)
            {
                return BadRequest();
            }

            _context.Entry(remarkableTrait).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RemarkableTraitExists(id))
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

        // POST: api/RemarkableTraits
        [HttpPost]
        public async Task<ActionResult<RemarkableTrait>> PostRemarkableTrait(RemarkableTrait remarkableTrait)
        {
            _context.RemarkableTrait.Add(remarkableTrait);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RemarkableTraitExists(remarkableTrait.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRemarkableTrait", new { id = remarkableTrait.Id }, remarkableTrait);
        }

        // DELETE: api/RemarkableTraits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RemarkableTrait>> DeleteRemarkableTrait(int id)
        {
            var remarkableTrait = await _context.RemarkableTrait.FindAsync(id);
            if (remarkableTrait == null)
            {
                return NotFound();
            }

            _context.RemarkableTrait.Remove(remarkableTrait);
            await _context.SaveChangesAsync();

            return remarkableTrait;
        }

        private bool RemarkableTraitExists(int id)
        {
            return _context.RemarkableTrait.Any(e => e.Id == id);
        }
    }
}
