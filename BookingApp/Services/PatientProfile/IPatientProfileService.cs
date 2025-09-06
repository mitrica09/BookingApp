using BookingApp.ViewModels.Account;

namespace BookingApp.Services.PatientProfile
{
    public interface IPatientProfileService
    {
        Task<bool> CreatePatientProfile(PatientProfileVM patientProfile);
    }
}
