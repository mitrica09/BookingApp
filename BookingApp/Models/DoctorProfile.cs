namespace BookingApp.Models
{
    public class DoctorProfile
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Specialities { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<Availability> Availabilities { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<DoctorService> DoctorServices { get; set; }

    }
}
