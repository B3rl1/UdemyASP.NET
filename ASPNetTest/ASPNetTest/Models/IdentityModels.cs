using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASPNetTest.Models
{
	public class ApplicationUser : IdentityUser
	{

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