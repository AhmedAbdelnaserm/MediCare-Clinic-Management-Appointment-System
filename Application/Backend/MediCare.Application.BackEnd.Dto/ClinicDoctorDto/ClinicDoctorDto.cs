using MediCare.Application.BackEnd.Dto.ClinicDto;

namespace MediCare.Application.BackEnd.Dto.ClinicDoctorDto;

public class ClinicDoctorDto
{
    public int ClinicDoctorId { get; set; }

    public int DoctorId { get; set; }

    public string DoctorName { get; set; } = string.Empty;

    public string DoctorEmail { get; set; } = string.Empty;

    public string DoctorPhone { get; set; } = string.Empty;

    public string SpecializationName { get; set; } = string.Empty;

    public int ConsultationDurationMinutes { get; set; }

    public bool IsActive { get; set; }

    public List<WorkingHourDto> WorkingHours { get; set; } = new();
}