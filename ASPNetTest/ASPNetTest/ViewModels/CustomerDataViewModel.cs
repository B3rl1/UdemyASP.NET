using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPNetTest.Models;

namespace ASPNetTest.ViewModels
{
	public class CustomerDataViewModel
	{
		public List<MembershipType> MembershipType { get; set; }
		public User User { get; set; }
	}
}