using System.ComponentModel.DataAnnotations;

namespace MVCSQ014_RazorViews.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public string Email { get; set; } = "";
    }
}
