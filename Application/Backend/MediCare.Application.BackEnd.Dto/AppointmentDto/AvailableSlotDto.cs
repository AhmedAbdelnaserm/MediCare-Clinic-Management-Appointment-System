namespace MediCare.Application.BackEnd.Dto.AppointmentDto;

public sealed class AvailableSlotDto
{
    public int SlotId { get; set; }
    public int DoctorId { get; set; }
    public string DoctorName { get; set; } = string.Empty;
    public string ClinicName { get; set; } = string.Empty;
    public string ClinicAddress { get; set; } = string.Empty;
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public decimal ConsultationFee { get; set; }
}
