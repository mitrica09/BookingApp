using Microsoft.AspNetCore.Identity;

namespace BookingApp.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
