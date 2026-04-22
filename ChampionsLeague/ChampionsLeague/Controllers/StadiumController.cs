using AutoMapper;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Services.Interfaces;
using ChampionsLeague.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChampionsLeague.Controllers
{
    public class StadiumController : Controller
    {
        private readonly IClubService _clubService;
        private readonly IService<Stadium> _stadiumService;
        private readonly IMapper _mapper;

        public StadiumController(
            IService<Stadium> stadiumService,
            IClubService clubService,
            IMapper mapper)
        {
            _stadiumService = stadiumService;
            _clubService = clubService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            // 1. Get clubs with a home stadium
            var clubs = await _clubService.GetAllWithHomeStadium();

            // 2. Map to CalendarSelectVM list
            var vmList = _mapper.Map<List<ClubSelectVM>>(clubs);

            // 3. Return the view with the mapped list
            return View(vmList);
        }
        [HttpGet]
        public async Task<IActionResult> GetStadiumByClub(int stadiumId)
        {
            var stadium = await _stadiumService.FindByIdAsync(stadiumId);

            if (stadium == null)
                return NotFound();

            var vm = _mapper.Map<StadiumVM>(stadium);

            return Json(vm);
        }

    }
}
