using ChampionsLeague.Domain.Entities;
using ChampionsLeague.Services.Interfaces;
using ChampionsLeague.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChampionsLeague.Controllers
{
    public class MatchController : Controller
    {
        private readonly IService<Match> _match;
        public MatchController(IService<Match> match)
        {
            _match = match;
        }
        public IActionResult Index()
        {

            var matches = _match.GetAllAsync();

            return View(matches);
        }

    }
}
