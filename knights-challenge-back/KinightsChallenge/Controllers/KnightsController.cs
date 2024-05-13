using KinightsChallenge.Models;
using KinightsChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace KinightsChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KnightsController : ControllerBase
    {
        private readonly IKnightService _knightService;

        public KnightsController(IKnightService knightService)
        {
            _knightService = knightService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Knight>>> Get()
        {
            var knights = await _knightService.GetAllKnightsAsync();
            return Ok(knights);
        }

        [HttpGet("filter=heroes")]
        public async Task<ActionResult<IEnumerable<Knight>>> GetHeroes()
        {
            var heroes = await _knightService.GetHeroKnightsAsync();
            return Ok(heroes);
        }

        [HttpPost]
        public async Task<ActionResult<Knight>> Create(Knight knight)
        {
            var createdKnight = await _knightService.CreateKnightAsync(knight);
            return CreatedAtAction(nameof(GetById), new { id = createdKnight.Id }, createdKnight);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Knight>> GetById(string id)
        {
            var knight = await _knightService.GetKnightByIdAsync(id);
            if (knight == null)
            {
                return NotFound();
            }
            return Ok(knight);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _knightService.DeleteKnightAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Knight knight)
        {
            if (id != knight.Id)
            {
                return BadRequest();
            }
            var updatedKnight = await _knightService.UpdateKnightAsync(id, knight);
            if (updatedKnight == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
