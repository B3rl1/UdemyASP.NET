using System.ComponentModel.DataAnnotations;

namespace ASPNetTest.Models
{
	public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Водительское удостоверение")]
        public string DrivingLicense { get; set; }
    }
}
