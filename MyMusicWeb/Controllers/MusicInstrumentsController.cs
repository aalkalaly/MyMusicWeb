using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMusicWebData;
using MyMusicWebDataModels;
using MyMusicWebViewModels;
using System.Globalization;
using System.Security.Claims;

namespace MyMusicWeb.Controllers
{
    public class MusicInstrumentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public MusicInstrumentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            string currentUserId = GetUserId();
            var model = await dbContext.MusicInstuments
                .Where(p => p.IsDeleted == false)
                .Select(p => new MusicalInstrumentsIndexViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Seller = p.Seller,
                    HasBought = p.MusicInstrumentsBuyers.Any(p => p.BuyerId == currentUserId)
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
            if (!ModelState.IsValid)
            {
                model.Categories = await dbContext.Categories
                .AsNoTracking()
                .ToListAsync();
                return View(model);
            }
            var newInstrument = new MusicInstuments
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                SellerId = GetUserId()
            };
            await dbContext.MusicInstuments.AddAsync(newInstrument);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string currentUserId = GetUserId();

            var model = await dbContext.MusicInstuments
                .Where(p => p.IsDeleted == false)
                .Where(g => g.MusicInstrumentsBuyers.Any(cl => cl.BuyerId == currentUserId))
                .Select(p => new MusicalInstrumentsIndexViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Seller = p.Seller,
                })
                .AsNoTracking()
                .ToListAsync();


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid id)
        {
            MusicInstuments? entity = await dbContext.MusicInstuments
                .Where(p => p.Id == id)
                .Include(p => p.MusicInstrumentsBuyers)
                .FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new ArgumentException();
            }
            string currentUserId = GetUserId();
            if (entity.MusicInstrumentsBuyers.Any(pc => pc.BuyerId == currentUserId))
            {
                return RedirectToAction("Cart");
            }
            entity.MusicInstrumentsBuyers .Add(new MusicInstrumentsBuyers ()
            {
                BuyerId = currentUserId,
                MusicInstrumentId = entity.Id
            });
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var model = await dbContext.MusicInstuments
                .Where(p => p.Id == id)
                .AsNoTracking()
                .Select(p => new MusicInstrumentsDetailsViewModel()
                {
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
        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
