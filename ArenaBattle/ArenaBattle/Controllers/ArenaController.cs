using ArenaBattle.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArenaBattle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArenaController(IArenaService arenaService) : ControllerBase
    {
        [HttpPost("create")]
        public IActionResult CreateArena([FromBody] int numberOfHeroes)
        {
            var arenaId = arenaService.CreateArena(numberOfHeroes);
            return Ok(new { ArenaId = arenaId });
        }

        [HttpPost("battle/{arenaId}")]
        public IActionResult Battle(int arenaId)
        {
            var arena = arenaService.GetArena(arenaId);
            if (arena == null)
            {
                return NotFound();
            }

            arenaService.ExecuteBattle(arena);
            return Ok(arena.History);
        }
    }
}
