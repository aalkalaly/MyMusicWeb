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

        

        public EventController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
           
        }
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
        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
            
               
        }
    }
}
