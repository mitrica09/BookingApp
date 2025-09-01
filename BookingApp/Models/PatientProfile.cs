namespace BookingApp.Models
{
    public class PatientProfile
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string CNP { get; set; }
        public enum GenderStatus { Female, Male, Other, Undisclosed }
        public GenderStatus Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Allergies { get; set; }
        public string? Notes { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
