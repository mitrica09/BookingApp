using BookingApp.ViewModels.Account;

namespace BookingApp.Repositories
{
    public interface IPatientProfileRepository
    {
        Task<bool> CreatePatientProfile(PatientProfileVM patientProfile);
    }
}
