namespace BookingApp.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public enum AppointmentStatus { Pending, Confirmed, Cancelled, NoShow, Completed }
        public AppointmentStatus Status { get; set; }
        public string? Reason { get; set; }
        public string? Notes { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public string? CancelReason { get; set; }
        public int PatientId { get; set; }
        public PatientProfile PatientProfile { get; set; }
        public int DoctorId { get; set; }
        public DoctorProfile DoctorProfile { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }

    }
}
