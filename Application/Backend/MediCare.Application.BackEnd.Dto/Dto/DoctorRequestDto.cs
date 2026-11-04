using System.ComponentModel.DataAnnotations;

namespace MediCare.Application.BackEnd.Dto.Dto;

public class DoctorRequestDto
{
    public int DoctorId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int SpecializationId { get; set; }
    public decimal ConsultationFee { get; set; }
    public string EnName { get; set; } = string.Empty;
    public string ArName { get; set; } = string.Empty;
    public string EnDescription { get; set; } = string.Empty;
    public string ArDescription { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ProfileImage { get; set; }
    public string? DoctorDegree { get; set; }
}
