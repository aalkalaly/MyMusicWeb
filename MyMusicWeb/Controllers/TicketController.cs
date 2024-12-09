using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWebViewModels.Event;
using MyMusicWebViewModels.Ticket;
using System.Security.Claims;

namespace MyMusicWeb.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService ticketService;
        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }
        public IActionResult MyTickets()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> BuyTickets(Guid id)
        {
            var model = new BuyTicketViewModel();
            
           
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> BuyTickets(BuyTicketViewModel model, Guid id)
        {
            model.BuyerId = GetUserId();
            model.EventId = id;
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", "Event");
            }
            
            if (model.BuyerId == null)
            {
                return Unauthorized("user isn't authenticated.");
            }
            model.BuyerId = GetUserId();
            var result = await ticketService.BuyTicketAsync(  model);
            if (!result)
            {
                return BadRequest("Faild to purchase a ticket");
            }
            return RedirectToAction("Details", "Event");
        }
        public IActionResult SetAvailableTickets()
        {
            throw new NotImplementedException();
        }
        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);


        }
    }
}
