using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMusicWeb.Controllers;

namespace MyMusicWeb.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]/[action]")]
    public class TicketApiController : BaseController
    {
        //public async Task<IActionResult> GetEv()
        //{
        //    return View();
        //}
    }
}
