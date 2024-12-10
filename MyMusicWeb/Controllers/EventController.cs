using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMusicWeb.Services.Data;
using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWebData;
using MyMusicWebDataModels;
using MyMusicWebViewModels;
using MyMusicWebViewModels.Category;
using MyMusicWebViewModels.Event;
using MyMusicWebViewModels.Genra;
using MyMusicWebViewModels.Locations;
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
        public async Task<IActionResult> Index(string? searchQuery = null)
        {
            string currentUserId = GetUserId();
            if (currentUserId != null)
            {
                IEnumerable<EventIndexViewModel> model =
                await this.eventService.IndexGetAllActualEventsAsync(currentUserId, searchQuery);
                return View(model);
            }

            return RedirectToAction("Index", "HomeController");

            
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

            model.HealderId = GetUserId();

            await this.eventService.AddEventsAsync(model);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {

         
                EventDetailsViewModel model = await eventService.EventsDetailsById(id);
                return View(model);
            
            return RedirectToAction("Idex");
            
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var genras = await dbContext.Genra
                .Select(c => new GenraViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
            var locations = await dbContext.Location
                .Select(c => new LocationViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Adress = c.Adress
                })
                .ToListAsync();
            var model = await dbContext.Events
                .Where(p => p.Id == id)
                .Select(p => new EventEditViewModel()
                {
                    Name = p.Name,
                    Date = p.Date,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    GenraId = p.GenraId,
                    Genras = genras,
                    LocationId = p.LocationId,
                    Locations = locations
                })
                .FirstOrDefaultAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EventEditViewModel model, Guid id)
        {
            if (!ModelState.IsValid)
            {
               
                model.Genras = await dbContext.Genra
                .Select(c => new GenraViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
                model.Locations = await dbContext.Location
               .Select(c => new LocationViewModel
               {
                   Id = c.Id,
                   Name = c.Name,
                   Adress = c.Adress
               })
               .ToListAsync();
                return View(model);
            }
            model.HealderId = GetUserId();
            Event entity = await dbContext.Events.FindAsync(id);

            await this.eventService.EditEventsById(model, entity);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await dbContext.Events
               .Where(p => p.Id == id)
               .AsNoTracking()
               .Select(p => new EventDeleteViewModel()
               {
                   Name = p.Name,
                   Id = p.Id
               })
               .FirstOrDefaultAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EventDeleteViewModel model)
        {
            await this.eventService.DeleteFromEventsById(model);
            return RedirectToAction("Index");
        }
        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
            
               
        }
    }
}
