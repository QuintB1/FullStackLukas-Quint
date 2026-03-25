using ChampionsLeague.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChampionsLeague.API
{
    [ApiController]
    [Route("api")]
    public class MatchesController : ControllerBase
    {
        private readonly MatchService _matchService;
        private readonly StadiumService _stadiumService;

        public MatchesController(MatchService matchService, StadiumService stadiumService)
        {
            _matchService = matchService;
            _stadiumService = stadiumService;
        }
        /*
        // 1. Stadiums
        [HttpGet("stadiums")]
        public async Task<IActionResult> GetAllStadiums(
    [FromServices] StadiumSectionService stadiumSectionService)
        {
            var stadiums = await _stadiumService.GetAllAsync();

            if (stadiums == null)
                return NotFound();

            var result = new List<object>();

            foreach (var stadium in stadiums)
            {
                // Fetch all sections for this stadium
                var sections = await stadiumSectionService.GetByStadiumIdAsync(stadium.StadiumId);

                var stadiumInfo = new
                {
                    stadium.StadiumId,
                    stadium.Name,
                    stadium.Address,

                    // Total capacity = sum of each section's capacity
                    TotalCapacity = sections.Sum(sec => sec.Capacity),

                    // Capacity per section type (each section already has full capacity)
                    CapacityPerSectionType = sections
                        .GroupBy(sec => sec.Name)
                        .Select(g => new
                        {
                            SectionType = g.Key,
                            Capacity = g.Sum(sec => sec.Capacity)
                        })
                };

                result.Add(stadiumInfo);
            }

            return Ok(result);
        }
        */


        // 3. Users
        [HttpGet("users")]
        public IActionResult GetUsers([FromServices] UserManager<IdentityUser> userManager)
        {
            var users = userManager.Users.Select(u => new
            {
                u.Id,
                u.UserName,
                u.Email,
                Roles = new List<string>()
            });

            return Ok(users);
        }
    }


}
