using System.ComponentModel.DataAnnotations;

namespace MVCSQ014_RazorViews.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
        public bool? RememberMe { get; set; }
    }
}
