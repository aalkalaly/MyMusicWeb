using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWeb.Services.Mapping;
using MyMusicWebViewModels.Area.UserManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWeb.Services.Data
{
	public class UserService : BaseService, IUserService
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly RoleManager<IdentityRole> roleManager;
		public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
		}

        public async Task<bool> AssignUserToRoleAsync(Guid userId, string roleName)
        {
            IdentityUser? user = await userManager.FindByIdAsync(userId.ToString());
			bool roleExists = await this.roleManager.RoleExistsAsync(roleName);
			if(user == null || !roleExists )
			{
				return false;
			}
            bool alreadyInRole = await this.userManager.IsInRoleAsync(user, roleName);
            if (!alreadyInRole)
			{
				IdentityResult? result = await this.userManager.AddToRoleAsync(user, roleName);
				if (!result.Succeeded)
				{
					return false;
				}
			}
			return true;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
			IdentityUser? user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return false;
            }
			IdentityResult? result = await this.userManager
				.DeleteAsync(user);
			if (!result.Succeeded)
			{
				return false;
			}
			return true;
        }

        public async Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync()
		{
			IEnumerable<IdentityUser> allUsers = await this.userManager
				.Users
				.ToArrayAsync();
			ICollection<AllUsersViewModel> allUsersViewModels = new List<AllUsersViewModel>();
			foreach (IdentityUser user in allUsers)
			{
				IEnumerable<string> roles = await userManager.GetRolesAsync(user);
				allUsersViewModels.Add(new AllUsersViewModel()
				{
					Id = user.Id.ToString(),
					Email = user.Email,
					Roles = roles
				});

			}
			return allUsersViewModels;
		}

        public async Task<bool> RemoveExistingRoleAsync(Guid userId, string roleName)
        {
            IdentityUser? user = await userManager.FindByIdAsync(userId.ToString());
            bool roleExists = await this.roleManager.RoleExistsAsync(roleName);
            if (user == null || !roleExists)
            {
                return false;
            }
            bool alreadyInRole = await this.userManager.IsInRoleAsync(user, roleName);
            if (alreadyInRole)
            {
                IdentityResult? result = await this.userManager.RemoveFromRoleAsync(user, roleName);
                if (!result.Succeeded)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<bool> UserExistsByIdAsync(Guid userId)
        {
			IdentityUser? user = await userManager.FindByIdAsync(userId.ToString());
			return user != null;
        }
    }
}
