using AutoMapper;
using ChampionsLeague.Domain.EntitiesDB;
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

        public async Task<IActionResult> Index()
        {
            try
            {
                var lstStadiums = await _stadiumDBService.GetAllAsync();
                List<StadiumVM>? stadiumVMs = null;


                if (lstStadiums != null)
                {
                    stadiumVMs = new List<StadiumVM>();
                    stadiumVMs = _mapper.Map<List<StadiumVM>>(lstStadiums);
                    return View(stadiumVMs);
                }
            }
            catch (Exception ex)
            {
                // Log de fout en geef een vriendelijke foutmelding terug
                ModelState.AddModelError("", "Er is een fout opgetreden bij het ophalen van de stadiums: " + ex.Message);

            }
            return View();
        }
    }
}
