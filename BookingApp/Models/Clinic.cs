namespace BookingApp.Models
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Availability> Availabilities { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }


    }
}
