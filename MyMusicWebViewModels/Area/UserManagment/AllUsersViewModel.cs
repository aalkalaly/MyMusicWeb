using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MyMusicWeb.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWebViewModels.Area.UserManagment
{
	public class AllUsersViewModel 
	{
		public string Id { get; set; }
		public string? Email { get; set; }
		public IEnumerable<string> Roles { get; set; }

		
	}
}
