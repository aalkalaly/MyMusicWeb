using Microsoft.AspNetCore.Mvc;
using MyMusicWebViewModels;
using System.Diagnostics;

namespace MyMusicWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // can be used to check the 500 error view
        //public IActionResult ManualError()
        //{
        //    return StatusCode(500);
        //}

        public IActionResult Index()
        {
            return View();
        }


        
        public IActionResult Error(int? statusCode = null)
        {

            if (!statusCode.HasValue)
            {
                return this.View();
            }

            if (statusCode == 404)
            {
                return this.View("NotFound");
            }

                return this.View("Error500");


        }
    }
}
