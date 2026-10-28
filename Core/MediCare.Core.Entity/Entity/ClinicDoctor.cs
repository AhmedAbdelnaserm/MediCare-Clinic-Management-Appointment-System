using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity;

public class ClinicDoctor : BaseEntity
{
    public int ClinicDoctorId { get; set; }

    public int ClinicId { get; set; }
    public Clinic Clinic { get; set; } = null!;

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;

    public ICollection<WorkingHour> WorkingHours { get; set; }
        = new List<WorkingHour>();
    public ICollection<Slot> Slots { get; set; }
    = new List<Slot>();
}
