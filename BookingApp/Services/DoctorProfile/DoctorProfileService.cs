using BookingApp.Repositories.DoctorProfile;
using BookingApp.ViewModels.Account;

namespace BookingApp.Services.DoctorProfile
{
    public class DoctorProfileService : IDoctorProfileService
    {
        private readonly DoctorProfileRepository _doctorProfileRepository;

        public DoctorProfileService(DoctorProfileRepository doctorProfileRepository)
        {
            _doctorProfileRepository = doctorProfileRepository;
        }

        public Task<bool> CreateDoctorProfile(DoctorProfileVM doctorProfile)
        {
            return _doctorProfileRepository.CreateDoctorProfile(doctorProfile);
        }
    }
}
