using BookingApp.ViewModels.Account;

namespace BookingApp.Repositories.PatientProfile
{
    public interface IPatientProfileRepository
    {
        Task<bool> CreatePatientProfile(PatientProfileVM patientProfile);
    }
}
