using System.ComponentModel.DataAnnotations;

namespace BookingApp.ViewModels.Account
{
    public class DoctorProfileVM
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Specialities { get; set; }
        public string Bio { get; set; }
    }
}
