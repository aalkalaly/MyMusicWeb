using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWebData;
using MyMusicWebData.Repository.Interfaces;
using MyMusicWebDataModels;
using MyMusicWebViewModels;
using System.Globalization;
using System.Security.Claims;

namespace MyMusicWeb.Controllers
{
    public class MusicInstrumentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        
        private readonly IMusicInstrumentsService musicInstrumentsService;

        public MusicInstrumentsController(ApplicationDbContext dbContext, IMusicInstrumentsService musicInstrumentsService)
        {
            this.dbContext = dbContext;
            this.musicInstrumentsService = musicInstrumentsService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string currentUserId = GetUserId();
            IEnumerable<MusicalInstrumentsIndexViewModel> model =
               await this.musicInstrumentsService.IndexGetAllNotDeletedAsync(currentUserId);

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
            if (!ModelState.IsValid)
            {
                model.Categories = await dbContext.Categories
                .AsNoTracking()
                .ToListAsync();
                return View(model);
            }
            model.SellerId = GetUserId();
            await this.musicInstrumentsService.AddMusicInstrumentsAsync(model);
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            MusicInstrumentsDetailsViewModel model = await musicInstrumentsService.MusicInstrumentsDetailsById(id);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var categories = await dbContext.Categories
                .Select(c => new CategoriesViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
            var model = await dbContext.MusicInstruments
                .Where(p => p.Id == id)
                .Select(p => new MusicInstrumentsEditViewModel()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    CategoryId = p.CategoryId,
                    Categories = categories,
                    SellerId = p.SellerId
                })
                .FirstOrDefaultAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MusicInstrumentsEditViewModel model, Guid id)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await dbContext.Categories
                .Select(c => new CategoriesViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
                return View(model);
            }
            MusicInstruments entity = await dbContext.MusicInstruments.FindAsync(id);

            await this.musicInstrumentsService.EditMusicInstrumentsById(model, entity);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await dbContext.MusicInstruments
               .Where(p => p.Id == id)
               .AsNoTracking()
               .Select(p => new MusicInstrumentsDeleteViewModels()
               {
                   Name = p.Name,
                   Seller = p.Seller.UserName,
                   SellerId = p.SellerId,
                   Id = p.Id
               })
               .FirstOrDefaultAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(MusicInstrumentsDeleteViewModels model)
        {
            await this.musicInstrumentsService.DeleteFromMusicInstruments(model);
            return RedirectToAction("Index");
        }
        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
