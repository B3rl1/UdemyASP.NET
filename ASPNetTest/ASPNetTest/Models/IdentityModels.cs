using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASPNetTest.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		[StringLength(255)]
		public string DrivingLicense { get; set; }
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			return userIdentity;
		}
	}

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<User> Users { get; set; }
		public DbSet<MembershipType> MembershipTypes { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<GenreType> GenreTypes { get; set; }

		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{

		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}