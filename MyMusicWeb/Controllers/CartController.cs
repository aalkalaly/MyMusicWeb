using Microsoft.AspNetCore.Mvc;
using MyMusicWebData.Repository.Interfaces;
using MyMusicWebData;
using MyMusicWebDataModels;
using Microsoft.EntityFrameworkCore;
using MyMusicWebViewModels;
using System.Security.Claims;
using MyMusicWeb.Services.Data.Interfaces;
namespace MyMusicWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICartService cartService;

        public CartController(ApplicationDbContext dbContext, ICartService cartService)
        {
            this.dbContext = dbContext;
            this.cartService = cartService;
        }
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string currentUserId = GetUserId();

            IEnumerable<MusicalInstrumentsIndexViewModel> model =
                await this.cartService.CartGetAllNotDeletedAsync(currentUserId);


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid id)
        {
           
            string currentUserId = GetUserId();
            await this.cartService.AddToCartById(id, currentUserId);

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

            // await this.cartService.RemoveFromCartById(id, currentUserId);

            return RedirectToAction("Cart");
        }
        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
