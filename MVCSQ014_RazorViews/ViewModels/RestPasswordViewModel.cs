using System.ComponentModel.DataAnnotations;

namespace MVCSQ014_RazorViews.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string Id { get; set; } = "";

        [Required]
        public string token { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        public string ConfirmPassword { get; set; } = "";
    }
}
