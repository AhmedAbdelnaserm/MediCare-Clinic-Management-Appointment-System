namespace MediCare.Application.BackEnd.Dto.AppointmentDto;

public sealed class PatientAppointmentDto
{
    public int AppointmentId { get; set; }
    public int SlotId { get; set; }
    public int DoctorId { get; set; }
    public string DoctorName { get; set; } = string.Empty;
    public string ClinicName { get; set; } = string.Empty;
    public string ClinicAddress { get; set; } = string.Empty;
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public int StatusId { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal ConsultationFee { get; set; }
}
