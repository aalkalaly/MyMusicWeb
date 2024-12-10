using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyMusicWebDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebData.Seeder
{
	public class AssignAdminRole
	{
		public static void AdminRoleSeeder(IServiceProvider serviceProvider)
		{
			var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

			string adminEmail = "admin@example.com";
			string adminPassword = "Admin@123";

			var adminUser = userManager.FindByEmailAsync(adminEmail).GetAwaiter().GetResult();
			if (adminUser == null)
			{
				adminUser = new IdentityUser
				{
					Id = "7682ff58-03bd-41b0-81fb-26b077c0050a",
                    UserName = adminEmail,
					Email = adminEmail
				};
				var createUserResult = userManager.CreateAsync(adminUser, adminPassword).GetAwaiter().GetResult();
				if (!createUserResult.Succeeded)
				{
					throw new Exception($"Failed to create admin user: {adminEmail}");
				}
			}

			var isInRole = userManager.IsInRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();
			if (!isInRole)
			{
				var addRoleResult = userManager.AddToRoleAsync(adminUser, "Admin").GetAwaiter().GetResult();
				if (!addRoleResult.Succeeded)
				{
					throw new Exception($"Failed to assign admin role to user: {adminEmail}");
				}
			}
		}
	}
}
