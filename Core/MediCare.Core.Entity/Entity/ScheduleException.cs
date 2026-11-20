using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity;

public sealed class ScheduleException : BaseEntity
{
    public int ScheduleExceptionId { get; set; }
    public int ClinicDoctorId { get; set; }
    public ClinicDoctor ClinicDoctor { get; set; } = null!;
    public DateOnly ExceptionDate { get; set; }
    public bool IsClosed { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }
    public string? Reason { get; set; }
}
