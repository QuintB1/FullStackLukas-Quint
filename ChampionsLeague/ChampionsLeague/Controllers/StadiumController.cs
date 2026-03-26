using AutoMapper;
using ChampionsLeague.Domain.Entities;
using ChampionsLeague.Services.Interfaces;
using ChampionsLeague.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ChampionsLeague.Controllers
{
    public class StadiumController : Controller
    {
        private readonly IService<Stadium> _stadiumDBService;
        private readonly IMapper _mapper;

        public StadiumController(IService<Stadium> stadiumDBService)
        {
            _stadiumDBService = stadiumDBService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            if (id <= 0)
                return BadRequest();

            // Ophalen via service (FindByIdAsync)
            var stadium = await _stadiumDBService.FindByIdAsync(id);

            if (stadium == null)
                return NotFound();

            // Stadium -> StadiumVM mappen (indien service geen VM teruggeeft)
            var vm = new StadiumVM
            {
                StadiumId = stadium.StadiumId,
                Name = stadium.Name,
                Address = stadium.Address,
                SubscriptionSeats = stadium.SubscriptionSeats
            };

            return View(vm);
        }
    }
}
