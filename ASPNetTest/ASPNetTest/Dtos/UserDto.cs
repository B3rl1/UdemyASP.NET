﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ASPNetTest.Models;

namespace ASPNetTest.Dtos
{
	public class UserDto
	{
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[Min18YearsIfAMember]
		public DateTime? DateOfBirthDay { get; set; }

		public bool IsSubscribedToNewsletter { get; set; }
		public byte MembershipTypeId { get; set; }
	}
}