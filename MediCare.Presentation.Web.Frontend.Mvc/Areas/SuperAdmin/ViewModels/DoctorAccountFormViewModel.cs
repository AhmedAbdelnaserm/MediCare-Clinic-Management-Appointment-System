using System.ComponentModel.DataAnnotations;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.SuperAdmin.ViewModels;

public sealed class DoctorAccountFormViewModel
{
    [Required, StringLength(150, MinimumLength = 2)]
    public string FullName { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(256)]
    public string Email { get; set; } = string.Empty;

    [Phone, StringLength(30)]
    public string? PhoneNumber { get; set; }

    [Required, MinLength(8), StringLength(128)]
    public string Password { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int SpecializationId { get; set; }

    [Range(0, 1000000)]
    public decimal ConsultationFee { get; set; }

    [Required, StringLength(200)]
    public string EnName { get; set; } = string.Empty;

    [Required, StringLength(4000)]
    public string EnDescription { get; set; } = string.Empty;

    [StringLength(500)]
    public string? DoctorDegree { get; set; }
}

public sealed class WorkingHourRowViewModel
{
    public int DayOfWeek { get; set; }
    public string DayName { get; set; } = string.Empty;
    public string ShiftName { get; set; } = string.Empty;
    public bool IsWorking { get; set; }
    public TimeOnly StartTime { get; set; } = new(9, 0);
    public TimeOnly EndTime { get; set; } = new(13, 0);
}

public sealed class ClinicDoctorScheduleViewModel
{
    public int ClinicDoctorId { get; set; }
    public List<WorkingHourRowViewModel> WorkingHours { get; set; } = [];
    public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(59));
    public DateOnly ExceptionDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(1));
    public bool ExceptionIsClosed { get; set; } = true;
    public TimeOnly? ExceptionStartTime { get; set; }
    public TimeOnly? ExceptionEndTime { get; set; }
    public string? ExceptionReason { get; set; }
    public List<MediCare.Application.BackEnd.Dto.AppointmentDto.ScheduleExceptionDto> Exceptions { get; set; } = [];
}
