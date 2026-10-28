using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity;

public class Prescription : BaseEntity
{
    public int PrescriptionId { get; set; }

    public int MedicalRecordId { get; set; }
    public MedicalRecord MedicalRecord { get; set; } = null!;

    public string? GeneralInstructions { get; set; }

    public ICollection<PrescriptionItem> Items { get; set; }
        = new List<PrescriptionItem>();
}
