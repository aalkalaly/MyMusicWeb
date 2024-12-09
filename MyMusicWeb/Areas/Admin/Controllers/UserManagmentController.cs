using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyMusicWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class UserManagmentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
