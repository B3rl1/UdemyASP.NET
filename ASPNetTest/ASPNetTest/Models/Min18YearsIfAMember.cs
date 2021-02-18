using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPNetTest.Models
{
	public class Min18YearsIfAMember : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var user = validationContext.ObjectInstance as User;

			if (user.MembershipTypeId == MembershipType.Unknown || user.MembershipTypeId == MembershipType.PayAsYouGo)
			{
				return ValidationResult.Success;
			}

			if (user.DateOfBirthDay == null)
			{
				return new ValidationResult("Необходимо указать день рождения!");
			}

			var age = DateTime.Today.Year - user.DateOfBirthDay.Value.Year;

			return (age >= 18)
				? ValidationResult.Success
				: new ValidationResult("Пользователь должен достичь 18 лет, чтобы оформить подписку");
		}
	}
}