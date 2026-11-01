using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity;

public class WorkingHour : BaseEntity
{
    public int WorkingHourId { get; set; }

    public int ClinicDoctorId { get; set; }
    public ClinicDoctor ClinicDoctor { get; set; } = null!;

    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly StartTime { get; set; } 
    public TimeOnly EndTime { get; set; } 
}
