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
            var newInstrument = new MusicInstruments
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                SellerId = GetUserId()
            };
            await dbContext.MusicInstruments.AddAsync(newInstrument);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var model = await dbContext.MusicInstruments
                .Where(p => p.Id == id)
                .AsNoTracking()
                .Select(p => new MusicInstrumentsDetailsViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    CategoryName = p.Category.Name,
                    Seller = p.Seller.UserName,
                    HasBought = p.MusicInstrumentsBuyers.Any(p => p.MusicInstrumentId == id)

                })
                .FirstOrDefaultAsync();
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
                    Categories = categories
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
            if (entity == null)
            {
                throw new ArgumentException();
            }

            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            entity.CategoryId = model.CategoryId;
            entity.SellerId = GetUserId();


            await dbContext.SaveChangesAsync();
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
            MusicInstruments? instrument = await dbContext.MusicInstruments
                .Where(p => p.Id == model.Id)
                .Where(p => p.IsDeleted == false)
                .FirstOrDefaultAsync();
            if (instrument != null)
            {
                instrument.IsDeleted = true;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
