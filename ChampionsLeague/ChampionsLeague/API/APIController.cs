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
