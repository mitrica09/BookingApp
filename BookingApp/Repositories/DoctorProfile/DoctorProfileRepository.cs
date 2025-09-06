using BookingApp.Data;
using BookingApp.Models;
using BookingApp.ViewModels.Account;
using Microsoft.AspNetCore.Identity;

namespace BookingApp.Repositories.DoctorProfile
{
    public class DoctorProfileRepository : IDoctorProfileRepository
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;

        public DoctorProfileRepository(AppDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<bool> CreateDoctorProfile(DoctorProfileVM doctorProfile)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var doctorProfileEntity = new Models.DoctorProfile
                    {
                        UserId = doctorProfile.UserId,
                        Specialities = doctorProfile.Specialities,
                        Bio = doctorProfile.Bio,

                    };
                    _db.DoctorProfiles.Add(doctorProfileEntity);
                    await _db.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
