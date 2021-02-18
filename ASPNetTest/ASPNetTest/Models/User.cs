using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace ASPNetTest.Models
{
	public class User
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Пожалуйста, введите имя пользователя")] //Not-nullable строка
		[StringLength(255)] //Ограничение по длине записи.
		public string Name { get; set; }


		[Display(Name = "Date of Birth")] //Изменение отображение в HTML
		[Min18YearsIfAMember]
		public DateTime? DateOfBirthDay { get; set; }

		public List<Ship> ShipList{ get; set; }

		public bool IsSubscribedToNewsletter { get; set; }

		public MembershipType MembershipType { get; set; }

		[Display(Name = "Membership Type")]
		public byte MembershipTypeId { get; set; } //Поскольку данное поле имеет значимый тип, то оно по умолчанию требуется и делает ValidationError

		//Аттрибуты данных для Validation
		//[Range(1,10)] - Минимальное или максимальное значение для данного свойства.
		//[Compare("OtherProperty")]
		//[Phone]
		//[EmailAddress]
		//[Url]
		//[RegularExpression("...")]

	}
}