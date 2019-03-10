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
    public class SkillsController : ControllerBase
    {
        private readonly FreedomContext _context;

        public SkillsController(FreedomContext context)
        {
            _context = context;
        }

        // GET: api/Skill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skills>>> GetSkills()
        {
            return await _context.Skills.ToListAsync();
        }

        // GET: api/Skill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Skills>> GetSkills(int id)
        {
            var skills = await _context.Skills.FindAsync(id);

            if (skills == null)
            {
                return NotFound();
            }

            return skills;
        }

        // PUT: api/Skill/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkills(int id, Skills skills)
        {
            if (id != skills.Id)
            {
                return BadRequest();
            }

            _context.Entry(skills).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillsExists(id))
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

        // POST: api/Skill
        [HttpPost]
        public async Task<ActionResult<Skills>> PostSkills(Skills skills)
        {
            _context.Skills.Add(skills);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkills", new { id = skills.Id }, skills);
        }

        // DELETE: api/Skill/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Skills>> DeleteSkills(int id)
        {
            var skills = await _context.Skills.FindAsync(id);
            if (skills == null)
            {
                return NotFound();
            }

            _context.Skills.Remove(skills);
            await _context.SaveChangesAsync();

            return skills;
        }

        private bool SkillsExists(int id)
        {
            return _context.Skills.Any(e => e.Id == id);
        }
    }
}
