using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity;

public class Appointment : BaseEntity
{
    public int AppointmentId { get; set; }

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    public int SlotId { get; set; }
    public Slot Slot { get; set; } = null!;

    public string? BookedByUserId { get; set; }
    public ApplicationUser? BookedByUser { get; set; }

    // Snapshot of the booked appointment time.
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }

    public int AppointmentStatusId { get; set; } = 1;

    public DateTime? CancelledAtUtc { get; set; }
    public string? CancellationReason { get; set; }

    public MedicalRecord? MedicalRecord { get; set; }
}
