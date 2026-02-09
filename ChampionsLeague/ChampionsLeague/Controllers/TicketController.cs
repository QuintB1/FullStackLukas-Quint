using Microsoft.AspNetCore.Mvc;

namespace ChampionsLeague.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
