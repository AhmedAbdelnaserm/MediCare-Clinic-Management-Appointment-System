using System.ComponentModel.DataAnnotations;

namespace MediCare.Application.BackEnd.Dto.MedicalRecordDto;

public sealed class CreateMedicalRecordRequestDto
{
    [Range(1, int.MaxValue)]
    public int AppointmentId { get; set; }

    [StringLength(4000)]
    public string? Symptoms { get; set; }

    [Required, StringLength(4000)]
    public string Diagnosis { get; set; } = string.Empty;

    [StringLength(8000)]
    public string? TreatmentNotes { get; set; }

    [StringLength(4000)]
    public string? PrescriptionInstructions { get; set; }

    [MaxLength(20)]
    public List<PrescriptionItemDto> PrescriptionItems { get; set; } = [];
}

public sealed class PrescriptionItemDto
{
    [StringLength(200)]
    public string MedicationName { get; set; } = string.Empty;

    [StringLength(200)]
    public string? Dosage { get; set; }

    [StringLength(200)]
    public string? Frequency { get; set; }

    [StringLength(200)]
    public string? Duration { get; set; }

    [StringLength(1000)]
    public string? Instructions { get; set; }
}

public sealed class DoctorAppointmentDto
{
    public int AppointmentId { get; set; }
    public int PatientId { get; set; }
    public string PatientName { get; set; } = string.Empty;
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
}

public sealed class MedicalRecordResponseDto
{
    public int MedicalRecordId { get; set; }
    public int AppointmentId { get; set; }
    public string DoctorName { get; set; } = string.Empty;
    public string PatientName { get; set; } = string.Empty;
    public DateTime AppointmentAt { get; set; }
    public string? Symptoms { get; set; }
    public string Diagnosis { get; set; } = string.Empty;
    public string? TreatmentNotes { get; set; }
    public string? PrescriptionInstructions { get; set; }
    public List<PrescriptionItemDto> PrescriptionItems { get; set; } = [];
    public List<MedicalRecordAttachmentDto> Attachments { get; set; } = [];
}
