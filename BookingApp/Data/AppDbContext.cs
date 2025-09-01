using BookingApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace BookingApp.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PatientProfile> PatientProfiles {  get; set; }
        public DbSet<DoctorProfile> DoctorProfiles { get; set; }
        public DbSet<AssistantProfile> AssistantProfiles { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<DoctorService> DoctorServices { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Appointment> Appointments { get; set; }



        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);

            // ---------- Profiles (1–0..1) ↔ AspNetUsers ----------
            b.Entity<PatientProfile>()
             .HasIndex(p => p.UserId)
             .IsUnique();
            b.Entity<PatientProfile>()
             .HasOne(p => p.User)
             .WithOne(u => u.PatientProfile)
             .HasForeignKey<PatientProfile>(p => p.UserId)
             .OnDelete(DeleteBehavior.Restrict);

            b.Entity<DoctorProfile>()
             .HasIndex(d => d.UserId)
             .IsUnique();
            b.Entity<DoctorProfile>()
             .HasOne(d => d.User)
             .WithOne(u => u.DoctorProfile)
             .HasForeignKey<DoctorProfile>(d => d.UserId)
             .OnDelete(DeleteBehavior.Restrict);

            b.Entity<AssistantProfile>()
             .HasIndex(a => a.UserId)
             .IsUnique();
            b.Entity<AssistantProfile>()
             .HasOne(a => a.User)
             .WithOne(u => u.AssistantProfile)
             .HasForeignKey<AssistantProfile>(a => a.UserId)
             .OnDelete(DeleteBehavior.Restrict);

            // ---------- Appointment ----------
            b.Entity<Appointment>()
             .HasOne(a => a.PatientProfile)
             .WithMany(p => p.Appointments)
             .HasForeignKey(a => a.PatientId)
             .OnDelete(DeleteBehavior.Restrict);

            b.Entity<Appointment>()
             .HasOne(a => a.DoctorProfile)
             .WithMany(d => d.Appointments)
             .HasForeignKey(a => a.DoctorId)
             .OnDelete(DeleteBehavior.Restrict);

            b.Entity<Appointment>()
             .HasOne(a => a.Clinic)
             .WithMany(c => c.Appointments)
             .HasForeignKey(a => a.ClinicId)
             .OnDelete(DeleteBehavior.Restrict);

            b.Entity<Appointment>()
             .HasOne(a => a.Room)
             .WithMany(r => r.Appointments)
             .HasForeignKey(a => a.RoomId)
             .OnDelete(DeleteBehavior.Restrict);

            b.Entity<Appointment>()
             .HasOne(a => a.Service)
             .WithMany(s => s.Appointments)
             .HasForeignKey(a => a.ServiceId)
             .OnDelete(DeleteBehavior.Restrict);

            // Audit: cine a creat programarea (FK -> AspNetUsers)
            b.Entity<Appointment>()
             .HasOne(a => a.CreatedByUser)
             .WithMany()
             .HasForeignKey(a => a.CreatedByUserId)
             .OnDelete(DeleteBehavior.Restrict);

            // Indexuri utile pentru căutări rapide
            b.Entity<Appointment>()
             .HasIndex(a => new { a.DoctorId, a.StartTime });
            b.Entity<Appointment>()
             .HasIndex(a => new { a.PatientId, a.StartTime });

            // ---------- Availability ----------
            b.Entity<Availability>()
             .HasOne(v => v.DoctorProfile)
             .WithMany(d => d.Availabilities)
             .HasForeignKey(v => v.DoctorId)
             .OnDelete(DeleteBehavior.Restrict);

            b.Entity<Availability>()
             .HasOne(v => v.Clinic)
             .WithMany(c => c.Availabilities)
             .HasForeignKey(v => v.ClinicId)
             .OnDelete(DeleteBehavior.Restrict);

            b.Entity<Availability>()
             .HasOne(v => v.Room)
             .WithMany(r => r.Availabilities)
             .HasForeignKey(v => v.RoomId)
             .OnDelete(DeleteBehavior.Restrict);

            b.Entity<Availability>()
             .HasIndex(v => new { v.DoctorId, v.Start, v.End });
            // ---------- Service ----------

            b.Entity<Service>()
             .Property(s => s.Price)
             .HasPrecision(18, 2); // precision=18, scale=2


            // ---------- DoctorService (M:N) ----------
            b.Entity<DoctorService>()
             .HasKey(ds => new { ds.DoctorId, ds.ServiceId });

            b.Entity<DoctorService>()
             .HasOne(ds => ds.DoctorProfile)
             .WithMany(d => d.DoctorServices)
             .HasForeignKey(ds => ds.DoctorId)
             .OnDelete(DeleteBehavior.Cascade);

            b.Entity<DoctorService>()
             .HasOne(ds => ds.Service)
             .WithMany(s => s.DoctorServices)
             .HasForeignKey(ds => ds.ServiceId)
             .OnDelete(DeleteBehavior.Cascade);

            // ---------- Mică igienă de schemă (opțional dar util) ----------
            b.Entity<User>()
             .Property(u => u.FullName)
             .HasMaxLength(200);

            b.Entity<Clinic>()
             .Property(c => c.Name)
             .HasMaxLength(200)
             .IsRequired();

            b.Entity<Room>()
             .Property(r => r.Name)
             .HasMaxLength(100)
             .IsRequired();

            b.Entity<Service>()
             .Property(s => s.Name)
             .HasMaxLength(200)
             .IsRequired();

            // Dacă vrei să salvezi enum-urile ca string în DB (mai lizibil),
            // decomentează linia următoare:
            // b.Entity<Appointment>().Property(a => a.Status).HasConversion<string>();
            // b.Entity<PatientProfile>().Property(p => p.Gender).HasConversion<string>();
        }
    }
}

