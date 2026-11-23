using MediCare.Application.BackEnd.Dto.ClinicDto;

namespace MediCare.Application.BackEnd.Dto.DoctorDto;

public class DoctorClinicSummaryDto
{
    public int ClinicId { get; set; }
    public string ClinicName { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public int ConsultationDurationMinutes { get; set; }
    public decimal ConsultationFee { get; set; }
    public List<WorkingHourDto> WorkingHours { get; set; } = new();
}
