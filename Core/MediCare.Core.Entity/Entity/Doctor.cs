using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity;

public class Doctor : BaseEntity
{
    public int DoctorId { get; set; }

    public string UserId { get; set; } = string.Empty;
    public ApplicationUser User { get; set; } = null!;

    public int SpecializationId { get; set; }
    public Specialization Specialization { get; set; } = null!;

    public decimal ConsultationFee { get; set; }


    public ICollection<ClinicDoctor> ClinicDoctors { get; set; }
        = new List<ClinicDoctor>();

    public ICollection<MedicalRecord> MedicalRecords { get; set; }
        = new List<MedicalRecord>();
}
