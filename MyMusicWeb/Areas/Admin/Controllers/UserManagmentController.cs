using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMusicWeb.Controllers;
using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWebData;
using MyMusicWebViewModels.Area.UserManagment;

namespace MyMusicWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class UserManagmentController : BaseController
	{
		private readonly IUserService userService;
        private readonly ApplicationDbContext dbContext;

		public UserManagmentController(IUserService userService, ApplicationDbContext dbContext)
		{
			this.userService = userService;
            this.dbContext = dbContext;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<AllUsersViewModel> allUsers = await this.userService
				.GetAllUsersAsync();
			return View(allUsers);
		}
		[HttpPost]
		public async Task<IActionResult> AssignRoles(string role, string userId)
		{
			Guid userIdGuid = Guid.Empty;
			if (!this.IsGuidValid(userId, ref userIdGuid))
			{
				return this.RedirectToAction(nameof(Index));
			}
			bool userExists = await this.userService
				.UserExistsByIdAsync(userIdGuid);
			if (!userExists)
			{
                return this.RedirectToAction(nameof(Index));
            }
			bool assignResult = await this.userService.AssignUserToRoleAsync(userIdGuid, role);
			if (!assignResult)
			{
				return this.RedirectToAction(nameof(Index));
            }
            return this.RedirectToAction(nameof(Index));
        }
		[HttpPost]
		public async Task<IActionResult>RemoveRole(string userId, string role)
		{
            Guid userIdGuid = Guid.Empty;
            if (!this.IsGuidValid(userId, ref userIdGuid))
            {
                return this.RedirectToAction(nameof(Index));
            }
            bool userExists = await this.userService
                .UserExistsByIdAsync(userIdGuid);
            if (!userExists)
            {
                return this.RedirectToAction(nameof(Index));
            }
            bool assignResult = await this.userService.RemoveExistingRoleAsync(userIdGuid, role);
            if (!assignResult)
            {
                return this.RedirectToAction(nameof(Index));
            }
            return this.RedirectToAction(nameof(Index));
        }
		[HttpPost]
		public async Task<IActionResult> DeleteUser(string userId)
		{
           

            Guid userIdGuid = Guid.Empty;
            if (!this.IsGuidValid(userId, ref userIdGuid))
            {
                return this.RedirectToAction(nameof(Index));
            }
            bool userExists = await this.userService
                .UserExistsByIdAsync(userIdGuid);
            if (!userExists)
            {
                return this.RedirectToAction(nameof(Index));
            }
            var musicInstrumentsBuyers = await dbContext.MusicInstrumentsBuyers
               .Where(u => u.BuyerId == userId)
               .ToListAsync();
            dbContext.MusicInstrumentsBuyers.RemoveRange(musicInstrumentsBuyers);
            await dbContext.SaveChangesAsync();

            bool assignResult = await this.userService.DeleteUserAsync(userIdGuid);
            if (!assignResult)
            {
                return this.RedirectToAction(nameof(Index));
            }
            return this.RedirectToAction(nameof(Index));
        }
	}
}
