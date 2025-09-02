using BookingApp.Data;
using BookingApp.Models;
using BookingApp.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace BookingApp.Repositories
{
    public class PatientProfileRepository : IPatientProfileRepository
    {
        private readonly AppDbContext _db;
        private readonly UserManager<User> _userManager;

        public PatientProfileRepository(AppDbContext db,UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<bool> CreatePatientProfile(PatientProfileVM patientProfile)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var patientProfileEntity = new PatientProfile
                    {
                        UserId = patientProfile.UserId,
                        CNP = patientProfile.CNP,
                        Gender = (PatientProfile.GenderStatus)patientProfile.Gender,
                        DateOfBirth = patientProfile.DateOfBirth.Value.Date,
                        Allergies = patientProfile.Allergies,
                        Notes = patientProfile.Notes
                    };
                    _db.PatientProfiles.Add(patientProfileEntity);
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
