using BookingApp.ViewModels.Account;

namespace BookingApp.Services
{
    public interface IPatientProfileService
    {
        Task<bool> CreatePatientProfile(PatientProfileVM patientProfile);
    }
}
