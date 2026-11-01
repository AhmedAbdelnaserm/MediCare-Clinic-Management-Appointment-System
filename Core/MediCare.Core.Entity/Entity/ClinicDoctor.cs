using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity;

public class ClinicDoctor : BaseEntity
{
    public int ClinicDoctorId { get; set; }
    public int ClinicId { get; set; }
    public int DoctorId { get; set; }
    public int ConsultationDurationMinutes { get; set; }
    public bool IsActive { get; set; } = true;


    public Clinic Clinic { get; set; } = null!;
    public Doctor Doctor { get; set; } = null!;

    public ICollection<WorkingHour> WorkingHours { get; set; }
        = new List<WorkingHour>();
    public ICollection<Slot> Slots { get; set; }
    = new List<Slot>();
}
