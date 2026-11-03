using System.ComponentModel.DataAnnotations;

namespace MediCare.Application.BackEnd.Dto.Dto;

public class DoctorRequestDto
{
    public int DoctorId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int SpecializationId { get; set; }
    public decimal ConsultationFee { get; set; }
    public string? Description { get; set; }
    public string? ProfileImage { get; set; }
    public string? GraduationCertificate { get; set; }
}
