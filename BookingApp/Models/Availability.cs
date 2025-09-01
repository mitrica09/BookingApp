namespace BookingApp.Models
{
    public class Availability
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DoctorProfile DoctorProfile { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Capacity { get; set; } = 1;

    }
}
