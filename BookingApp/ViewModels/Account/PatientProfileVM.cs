using System.ComponentModel.DataAnnotations;

namespace BookingApp.ViewModels.Account
{
    public class PatientProfileVM
    {

        public string UserId { get; set; }
        [Required(ErrorMessage = "CNP is required.")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "CNP must contain exactly 13 digits.")] public string CNP { get; set; }
        public enum GenderStatus { Female, Male, Other, Undisclosed }
        public GenderStatus Gender {  get; set; }
        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public string Allergies { get; set; }
        public string Notes { get; set; }

    }
}
