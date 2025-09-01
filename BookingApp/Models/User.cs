using Microsoft.AspNetCore.Identity;

namespace BookingApp.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public PatientProfile PatientProfile { get; set; }
        public DoctorProfile DoctorProfile { get; set; }
        public AssistantProfile AssistantProfile { get; set; }

    }
}
