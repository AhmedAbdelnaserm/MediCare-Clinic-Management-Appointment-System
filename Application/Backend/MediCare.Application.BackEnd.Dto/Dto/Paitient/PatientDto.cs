namespace MediCare.Application.BackEnd.Dto.Dto.Paitient
{
    public class PatientDto
    {
        public int PatientId { get; set; }

        // ApplicationUser relationship
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }

        public DateOnly? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? MedicalHistory { get; set; }
        public string? Allergies { get; set; }
    }
}
