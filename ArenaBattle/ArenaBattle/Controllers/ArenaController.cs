using ArenaBattle.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArenaBattle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArenaController : ControllerBase
    {
        private readonly ArenaService _arenaService;

        public ArenaController(ArenaService arenaService)
        {
            _arenaService = arenaService;
        }

        [HttpPost("create")]
        public IActionResult CreateArena([FromBody] int numberOfHeroes)
        {
            var arenaId = _arenaService.CreateArena(numberOfHeroes);
            return Ok(new { ArenaId = arenaId });
        }

        [HttpPost("battle/{arenaId}")]
        public IActionResult Battle(int arenaId)
        {
            var arena = _arenaService.GetArena(arenaId);
            if (arena == null)
            {
                return NotFound();
            }

            _arenaService.ExecuteBattle(arena);
            return Ok(arena.History);
        }
    }
}
