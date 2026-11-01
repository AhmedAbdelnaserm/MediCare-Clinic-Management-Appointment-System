using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity;

public class MedicalRecord : BaseEntity
{
    public int MedicalRecordId { get; set; }

    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; } = null!;

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;

    public string? Symptoms { get; set; }
    public string Diagnosis { get; set; } = string.Empty;
    public string? TreatmentNotes { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; }
        = new List<Prescription>();
}
