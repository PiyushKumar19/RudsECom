using System.ComponentModel.DataAnnotations;

namespace RudsECom.ViewModel
{
    public class RegisterViewModel
    {
        //public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "Email Not Matched")]
        public string ConfirmEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password Not Matched")]
        public string ConfirmPassword { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }
    }
}
