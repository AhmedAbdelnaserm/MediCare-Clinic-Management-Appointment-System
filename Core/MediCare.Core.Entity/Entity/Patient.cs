using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity;

public class Patient : BaseEntity
{
    public int PatientId { get; set; }

    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }

    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateOnly? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? MedicalHistory { get; set; }
    public string? Allergies { get; set; }

    public ICollection<Appointment> Appointments { get; set; }
        = new List<Appointment>();

    public ICollection<MedicalRecord> MedicalRecords { get; set; }
        = new List<MedicalRecord>();
}
