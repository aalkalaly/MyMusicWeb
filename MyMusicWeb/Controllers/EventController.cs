using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWebData;
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


        public EventController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
           
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string currentUserId = GetUserId();
            var model = await dbContext.Events
                .Where(p => p.IsActual != false)
                .Select(p => new EventIndexViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Date = p.Date,
                    ImageUrl = p.ImageUrl,
                    IsActual = p.IsActual
                })
                .AsNoTracking()
                .ToListAsync();
     
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new MusicInstrumentsAddViewModel();
            model.Categories = await dbContext.Categories
                .AsNoTracking()
                .ToListAsync();


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(MusicInstrumentsAddViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    model.Categories = await dbContext.Categories
            //    .AsNoTracking()
            //    .ToListAsync();
            //    return View(model);
            //}
            //model.SellerId = GetUserId();
            //await this.eventService.AddMusicInstrumentsAsync(model);
            return RedirectToAction("Index");
        }
        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
            
               
        }
    }
}
