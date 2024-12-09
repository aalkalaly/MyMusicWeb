using MyMusicWebViewModels.Area.UserManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWeb.Services.Data.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();
		Task<bool> UserExistsByIdAsync(Guid userId);
		Task<bool> AssignUserToRoleAsync(Guid userId, string roleName);
		Task<bool> RemoveExistingRoleAsync(Guid userId, string roleName);
		Task<bool> DeleteUserAsync(Guid userId);
	}
}
