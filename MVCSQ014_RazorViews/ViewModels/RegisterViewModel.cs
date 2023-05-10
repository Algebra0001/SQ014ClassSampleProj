using System.ComponentModel.DataAnnotations;

namespace MVCSQ014_RazorViews.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="Password mismatch!")]
        public string ConfirmPassword { get; set; } = "";
    }
}
