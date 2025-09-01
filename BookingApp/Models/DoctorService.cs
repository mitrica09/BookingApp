namespace BookingApp.Models
{
    public class DoctorService
    {
        public int DoctorId { get; set; }
        public DoctorProfile DoctorProfile { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }

    }
}
