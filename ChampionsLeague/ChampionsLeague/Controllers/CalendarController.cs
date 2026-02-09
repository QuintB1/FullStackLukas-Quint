using Microsoft.AspNetCore.Mvc;

namespace ChampionsLeague.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
