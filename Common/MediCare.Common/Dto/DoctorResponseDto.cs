namespace MediCare.Common.Dto;

public class DoctorResponseDto
{
    public string DoctorName { get; set; } = string.Empty;
    public string DoctorEmail { get; set; } = string.Empty;
    public string DoctorPhone { get; set; } = string.Empty;
    public int SpecializationId { get; set; }
    public string SpecializationName { get; set; } = string.Empty;
    public string ClinicName { get; set; } = string.Empty;
    public decimal ConsultationFee { get; set; }
    public string? Description { get; set; }
    public string? ProfileImage { get; set; }
    public string? DoctorDegree { get; set; }
}
