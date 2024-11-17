using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWebData;
using MyMusicWebDataModels;
using MyMusicWebViewModels;
using System.Security.Claims;

namespace MyMusicWeb.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IEventService eventService;

        public EventController(ApplicationDbContext dbContext, IEventService eventService)
        {
            this.dbContext = dbContext;
            this.eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string currentUserId = GetUserId();
            IEnumerable<EventIndexViewModel> model =
                await this.eventService.IndexGetAllActualEventsAsync(currentUserId);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new EventAddViewModel();
            model.Genras = await dbContext.Genra
                .AsNoTracking()
                .ToListAsync();
            model.Locations = await dbContext.Location
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(EventAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Locations = await dbContext.Location
                .AsNoTracking()
                .ToListAsync();
                model.Genras = await dbContext.Genra
                .AsNoTracking()
                .ToListAsync();
                return View(model);
            }

            
            await this.eventService.AddMusicInstrumentsAsync(model);

            return RedirectToAction("Index");
        }

        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
            
               
        }
    }
}
