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
    public class CharacterRemarkableTraitsController : ControllerBase
    {
        private readonly FreedomContext _context;

        public CharacterRemarkableTraitsController(FreedomContext context)
        {
            _context = context;
        }

        // GET: api/CharacterRemarkableTraits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterRemarkableTrait>>> GetCharacterRemarkableTrait()
        {
            return await _context.CharacterRemarkableTrait.ToListAsync();
        }

        // GET: api/CharacterRemarkableTraits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterRemarkableTrait>> GetCharacterRemarkableTrait(int id)
        {
            var characterRemarkableTrait = await _context.CharacterRemarkableTrait.FindAsync(id);

            if (characterRemarkableTrait == null)
            {
                return NotFound();
            }

            return characterRemarkableTrait;
        }

        // PUT: api/CharacterRemarkableTraits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacterRemarkableTrait(int id, CharacterRemarkableTrait characterRemarkableTrait)
        {
            if (id != characterRemarkableTrait.Id)
            {
                return BadRequest();
            }

            _context.Entry(characterRemarkableTrait).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterRemarkableTraitExists(id))
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

        // POST: api/CharacterRemarkableTraits
        [HttpPost]
        public async Task<ActionResult<CharacterRemarkableTrait>> PostCharacterRemarkableTrait(CharacterRemarkableTrait characterRemarkableTrait)
        {
            _context.CharacterRemarkableTrait.Add(characterRemarkableTrait);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CharacterRemarkableTraitExists(characterRemarkableTrait.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCharacterRemarkableTrait", new { id = characterRemarkableTrait.Id }, characterRemarkableTrait);
        }

        // DELETE: api/CharacterRemarkableTraits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CharacterRemarkableTrait>> DeleteCharacterRemarkableTrait(int id)
        {
            var characterRemarkableTrait = await _context.CharacterRemarkableTrait.FindAsync(id);
            if (characterRemarkableTrait == null)
            {
                return NotFound();
            }

            _context.CharacterRemarkableTrait.Remove(characterRemarkableTrait);
            await _context.SaveChangesAsync();

            return characterRemarkableTrait;
        }

        private bool CharacterRemarkableTraitExists(int id)
        {
            return _context.CharacterRemarkableTrait.Any(e => e.Id == id);
        }
    }
}
