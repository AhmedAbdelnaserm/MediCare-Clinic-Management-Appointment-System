namespace MediCare.Application.BackEnd.Dto.Dto;

public class UpdateDoctorRequestDto 
{
    public int SpecializationId { get; set; }
    public decimal ConsultationFee { get; set; }
    public string EnName { get; set; } = string.Empty;
    public string EnDescription { get; set; } = string.Empty;
    public string? ProfileImage { get; set; }
    public string? DoctorDegree { get; set; }
}
