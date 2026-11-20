using System.ComponentModel.DataAnnotations;

namespace MediCare.Application.BackEnd.Dto.AppointmentDto;

public sealed class CreateClinicDoctorScheduleDto
{
    [Range(1, int.MaxValue)]
    public int ClinicId { get; set; }

    [Range(1, int.MaxValue)]
    public int DoctorId { get; set; }

    [Range(5, 240)]
    public int ConsultationDurationMinutes { get; set; }
}

public sealed class WorkingHourDto
{
    [Range(0, 6)]
    public int DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}

public sealed class ReplaceWorkingHoursDto
{
    [MinLength(1)]
    public List<WorkingHourDto> WorkingHours { get; set; } = [];
}

public sealed class GenerateSlotsDto
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}

public sealed class GeneratedSlotsDto
{
    public int CreatedCount { get; set; }
}

public sealed class ClinicDoctorScheduleSummaryDto
{
    public int ClinicDoctorId { get; set; }
    public int ClinicId { get; set; }
    public string ClinicName { get; set; } = string.Empty;
    public string DoctorName { get; set; } = string.Empty;
    public string SpecializationName { get; set; } = string.Empty;
    public int ConsultationDurationMinutes { get; set; }
    public int WorkingDaysCount { get; set; }
    public bool IsActive { get; set; }
}

public sealed class ClinicDoctorScheduleDetailsDto
{
    public int ClinicDoctorId { get; set; }
    public string ClinicName { get; set; } = string.Empty;
    public string DoctorName { get; set; } = string.Empty;
    public int ConsultationDurationMinutes { get; set; }
    public List<WorkingHourDto> WorkingHours { get; set; } = [];
}
