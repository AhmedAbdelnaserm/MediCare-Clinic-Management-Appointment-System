namespace MediCare.Application.BackEnd.Dto.AppointmentDto;

public sealed class ScheduleExceptionDto
{
    public int ScheduleExceptionId { get; set; }
    public int ClinicDoctorId { get; set; }
    public DateOnly ExceptionDate { get; set; }
    public bool IsClosed { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }
    public string? Reason { get; set; }
}

public sealed class SaveScheduleExceptionDto
{
    public DateOnly ExceptionDate { get; set; }
    public bool IsClosed { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }
    public string? Reason { get; set; }
}
