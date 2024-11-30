using Microsoft.AspNetCore.Mvc;

namespace MyMusicWeb.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult MyTickets()
        {
            return View();
        }
        public IActionResult BuyTickets()
        {
            throw new NotImplementedException();
        }
        public IActionResult SetAvailableTickets()
        {
            throw new NotImplementedException();
        }
    }
}
