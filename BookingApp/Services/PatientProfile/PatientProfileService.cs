using BookingApp.Repositories.PatientProfile;
using BookingApp.ViewModels.Account;
using System.Security.AccessControl;

namespace BookingApp.Services.PatientProfile
{
    public class PatientProfileService : IPatientProfileService
    {
        private readonly IPatientProfileRepository _patientProfileRepository;

        public PatientProfileService(IPatientProfileRepository patientProfileRepository)
        {
            _patientProfileRepository = patientProfileRepository;
        }

        public Task<bool> CreatePatientProfile(PatientProfileVM patientProfile)
        {
            return _patientProfileRepository.CreatePatientProfile(patientProfile);
        }
    }
}
