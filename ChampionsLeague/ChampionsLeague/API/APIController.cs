using ChampionsLeague.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChampionsLeague.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchesController : ControllerBase
    {
        private readonly MatchService _matchService;

        public MatchesController(MatchService matchService)
        {
            _matchService = matchService;
        }
        [HttpGet("top10")]
        public async Task<IActionResult> GetTop10UpcomingMatches()
        {
            var matches = await _matchService.GetTop10UpcomingMatchesAsync();
            return Ok(matches);
        }

    }

}
