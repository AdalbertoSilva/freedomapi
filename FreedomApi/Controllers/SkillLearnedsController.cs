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
    public class SkillLearnedsController : ControllerBase
    {
        private readonly FreedomContext _context;

        public SkillLearnedsController(FreedomContext context)
        {
            _context = context;
        }

        // GET: api/SkillLearneds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillLearned>>> GetSkillLearned()
        {
            return await _context.SkillLearned.ToListAsync();
        }

        // GET: api/SkillLearneds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillLearned>> GetSkillLearned(int id)
        {
            var skillLearned = await _context.SkillLearned.FindAsync(id);

            if (skillLearned == null)
            {
                return NotFound();
            }

            return skillLearned;
        }

        // PUT: api/SkillLearneds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkillLearned(int id, SkillLearned skillLearned)
        {
            if (id != skillLearned.Id)
            {
                return BadRequest();
            }

            _context.Entry(skillLearned).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillLearnedExists(id))
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

        // POST: api/SkillLearneds
        [HttpPost]
        public async Task<ActionResult<SkillLearned>> PostSkillLearned(SkillLearned skillLearned)
        {
            _context.SkillLearned.Add(skillLearned);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SkillLearnedExists(skillLearned.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSkillLearned", new { id = skillLearned.Id }, skillLearned);
        }

        // DELETE: api/SkillLearneds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SkillLearned>> DeleteSkillLearned(int id)
        {
            var skillLearned = await _context.SkillLearned.FindAsync(id);
            if (skillLearned == null)
            {
                return NotFound();
            }

            _context.SkillLearned.Remove(skillLearned);
            await _context.SaveChangesAsync();

            return skillLearned;
        }

        private bool SkillLearnedExists(int id)
        {
            return _context.SkillLearned.Any(e => e.Id == id);
        }
    }
}
