using AutoMapper;
using ChampionsLeague.Services;
using ChampionsLeague.Services.Interfaces;
using ChampionsLeague.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChampionsLeague.API
{
    [ApiController]
    [Route("api")]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IMapper _mapper;

        public MatchesController(MatchService matchService, IMapper mapper)
        {
            _matchService = matchService;
            _mapper = mapper;
        }
        
        // 1. Stadiums
        [HttpGet("stadiums")]
        public async Task<IActionResult> GetAllStadiums()
        {
            var stadiums = await _matchService.GetAllStadiums();

            if (stadiums == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<List<StadiumVM>>(stadiums);

            return Ok(result);
        }


        // 3. Users
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers([FromServices] UserManager<IdentityUser> userManager)
        {
            var users = userManager.Users.ToList();

            var result = new List<object>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);

                result.Add(new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    Roles = roles
                });
            }

            return Ok(result);
        }

        [HttpGet("matches")]
        public async Task<IActionResult> matches(int homeclub, int awayclub)
        {
            var matchEntities = await _matchService.GetAllMatchesWithClubIdAsync(homeclub, awayclub);

            if (matchEntities == null)
                return NotFound();

            var matchVMs = _mapper.Map<List<MatchVM>>(matchEntities);

            return Ok(matchVMs);
        }

    }


}
