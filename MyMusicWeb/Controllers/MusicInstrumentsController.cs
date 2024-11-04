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
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(Guid id)
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
            MusicInstrumentsBuyers? productClient = entity.MusicInstrumentsBuyers.FirstOrDefault(pc => pc.BuyerId == currentUserId);
            if (productClient != null)
            {
                entity.MusicInstrumentsBuyers.Remove(productClient);
                await dbContext.SaveChangesAsync();
            }


            return RedirectToAction("Cart");
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var model = await dbContext.MusicInstuments
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
            var model = await dbContext.MusicInstuments
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

         
            MusicInstuments entity = await dbContext.MusicInstuments.FindAsync(id);
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
        //[HttpGet]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var model = await context.Products
        //       .Where(p => p.Id == id)
        //       .AsNoTracking()
        //       .Select(p => new ProductDeleteViewModels()
        //       {
        //           ProductName = p.ProductName,
        //           Seller = p.Seller.UserName,
        //           SellerId = p.SellerId,
        //           Id = p.Id
        //       })
        //       .FirstOrDefaultAsync();
        //    return View(model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Delete(ProductDeleteViewModels model)
        //{
        //    Product? product = await context.Products
        //        .Where(p => p.Id == model.Id)
        //        .Where(p => p.IsDeleted == false)
        //        .FirstOrDefaultAsync();
        //    if (product != null)
        //    {
        //        product.IsDeleted = true;
        //        await context.SaveChangesAsync();
        //    }
        //    return RedirectToAction("Index");
        //}
        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
