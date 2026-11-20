namespace MediCare.Application.BackEnd.Dto.DoctorDto;

public class DoctorResponseDto
{
    public int DoctorId { get; set; }
    public string DoctorName { get; set; } = string.Empty;
    public int SpecializationId { get; set; }
    public string SpecializationName { get; set; } = string.Empty;
    public string ClinicName { get; set; } = string.Empty;
    public decimal ConsultationFee { get; set; }
    public string? Description { get; set; }
    public string? ProfileImage { get; set; }
    public string? DoctorDegree { get; set; }
}
