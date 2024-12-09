using Microsoft.AspNetCore.Mvc;
using MyMusicWebData.Repository.Interfaces;
using MyMusicWebData;
using MyMusicWebDataModels;
using Microsoft.EntityFrameworkCore;
using MyMusicWebViewModels;
using System.Security.Claims;
using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWebViewModels.Event;
using Microsoft.AspNetCore.Authorization;
using MyMusicWebViewModels.Ticket;
namespace MyMusicWeb.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> CartForInstruments()
        {
            string currentUserId = GetUserId();
            if ( string.IsNullOrWhiteSpace (currentUserId))
            {
                return RedirectToPage("/Identity/Account/Login");
            }

            IEnumerable<MusicalInstrumentsIndexViewModel> model =
                await this.cartService.CartGetAllNotDeletedInstrumentsAsync(currentUserId);


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddInstrumentToCart(Guid id)
        {
           
            string currentUserId = GetUserId();
            await this.cartService.AddInstrumentsToCartById(id, currentUserId);

            return RedirectToAction("CartForInstruments");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveInstrumentFromCart(Guid id)
        {
            
            string currentUserId = GetUserId();
            await this.cartService.RemoveInstrumentsFromCartById(id, currentUserId);

            return RedirectToAction("CartForInstruments");
        }
        [HttpGet]
        public async Task<IActionResult> CartForEvents()
        {
            string currentUserId = GetUserId();
            if (string.IsNullOrWhiteSpace(currentUserId))
            {
                return RedirectToPage("/Identity/Account/Login");
            }

            IEnumerable<EventAddToCart> model =
                await this.cartService.CartGetAllNotDeletedEventsAsync(currentUserId);


            return View(model);
        }
        
        

        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
