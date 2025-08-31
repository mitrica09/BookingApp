using System.ComponentModel.DataAnnotations;

namespace BookingApp.ViewModels.Account
{
    public class VerifyEmailVM
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
