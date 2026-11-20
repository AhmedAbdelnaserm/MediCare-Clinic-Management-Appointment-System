namespace MediCare.Application.BackEnd.Dto.DoctorDto;

public class CreateDoctorRequestDto
{
    public string UserId { get; set; } = string.Empty;
    public int SpecializationId { get; set; }
    public decimal ConsultationFee { get; set; }=0;
    public string EnName { get; set; } = string.Empty;
    public string EnDescription { get; set; } = string.Empty;
    public string? ProfileImage { get; set; }
    public string? DoctorDegree { get; set; }

}
