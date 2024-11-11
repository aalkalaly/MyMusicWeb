using Microsoft.AspNetCore.Mvc;
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
        public async IActionResult Index()
        {
            string currentUserId = GetUserId();
            var model = await dbContext.Events
                .Where(p => p.IsActual != false)
                .Select(p => new() EventIndexViewModel()
                {

                })

                // .AsNoTracking()
                //.ToListAsync();
            return View();
        }
        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
            
               
        }
    }
}
