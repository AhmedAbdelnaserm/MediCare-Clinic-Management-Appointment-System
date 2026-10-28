using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity;

public class PrescriptionItem : BaseEntity
{
    public int PrescriptionItemId { get; set; }

    public int PrescriptionId { get; set; }
    public Prescription Prescription { get; set; } = null!;

    public string MedicationName { get; set; } = string.Empty;
    public string? Dosage { get; set; }
    public string? Frequency { get; set; }
    public string? Duration { get; set; }
    public string? Instructions { get; set; }
}
