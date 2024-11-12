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
            if ( string.IsNullOrWhiteSpace (currentUserId))
            {
                return RedirectToPage("/Identity/Account/Login");
            }

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
            
            string currentUserId = GetUserId();
            await this.cartService.RemoveFromCartById(id, currentUserId);

            return RedirectToAction("Cart");
        }
        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
