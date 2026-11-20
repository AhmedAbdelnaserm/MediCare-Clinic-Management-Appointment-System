namespace MediCare.Application.BackEnd.Dto.AppointmentDto;

public sealed class ClinicAppointmentDto
{
    public int AppointmentId { get; set; }
    public string PatientName { get; set; } = string.Empty;
    public string DoctorName { get; set; } = string.Empty;
    public string ClinicName { get; set; } = string.Empty;
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public int StatusId { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal ConsultationFee { get; set; }
}
