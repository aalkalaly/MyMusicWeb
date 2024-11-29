using Microsoft.AspNetCore.Mvc;

namespace MyMusicWeb.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
