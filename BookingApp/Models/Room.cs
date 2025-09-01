namespace BookingApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public string Name { get; set; }
        public string Equipment {  get; set; }
        public virtual ICollection<Availability> Availabilities { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
