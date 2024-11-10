using Microsoft.AspNetCore.Mvc;
using MyMusicWebData.Repository.Interfaces;
using MyMusicWebData;
using MyMusicWebDataModels;
using Microsoft.EntityFrameworkCore;
using MyMusicWebViewModels;
using System.Security.Claims;

namespace MyMusicWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private IRepository<MusicInstruments, Guid> movieRepository;

        public CartController(ApplicationDbContext dbContext, IRepository<MusicInstruments, Guid> movieRepository)
        {
            this.dbContext = dbContext;
            this.movieRepository = movieRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string currentUserId = GetUserId();

            var model = await dbContext.MusicInstruments
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
            MusicInstruments? entity = await dbContext.MusicInstruments
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
            entity.MusicInstrumentsBuyers.Add(new MusicInstrumentsBuyers()
            {
                BuyerId = currentUserId,
                MusicInstrumentId = entity.Id
            });
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Cart");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(Guid id)
        {
            MusicInstruments? entity = await dbContext.MusicInstruments
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
        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
