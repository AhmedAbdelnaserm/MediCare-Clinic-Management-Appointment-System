using System.ComponentModel.DataAnnotations;

namespace MediCare.Application.BackEnd.Dto.Dto.Paitient
{
    public class UpdatePatientDto
    {
        [Required(ErrorMessage = "Patient id is required.")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [Range(1, 3, ErrorMessage = "Gender must be 1 (Male), 2 (Female) or 3 (Other).")]
        public int GenderId { get; set; }

        [StringLength(2000, ErrorMessage = "Medical history cannot exceed 2000 characters.")]
        public string? MedicalHistory { get; set; }

        [StringLength(1000, ErrorMessage = "Allergies cannot exceed 1000 characters.")]
        public string? Allergies { get; set; }
    }
}
