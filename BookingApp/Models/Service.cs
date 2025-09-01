using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApp.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public string Speciality { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<DoctorService> DoctorServices { get; set; }

    }
}
