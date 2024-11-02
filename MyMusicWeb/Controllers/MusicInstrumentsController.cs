using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMusicWebData;
using MyMusicWebDataModels;
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
            //string currentUserId = GetUserId();
            //var model = await dbContext.MusicInstuments
            //    .Where(p => p.IsDeleted == false)
            //    .Select(p => new ProductIndexModelView()
            //    {
            //        Id = p.Id,
            //        ProductName = p.ProductName,
            //        ImageUrl = p.ImageUrl,
            //        Price = p.Price,
            //        Seller = p.Seller,
            //        HasBought = p.ProductsClients.Any(p => p.ClientId == currentUserId)
            //    })
            //    .AsNoTracking()
            //    .ToListAsync();


            return View();
        }
        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
