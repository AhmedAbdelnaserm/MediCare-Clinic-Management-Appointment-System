namespace MediCare.Application.BackEnd.Dto.DoctorDto;

public class UpdateDoctorProfileRequestDto
{
    public int SpecializationId { get; set; }
    public string? DoctorDegree { get; set; }
    public string EnDescription { get; set; } = string.Empty;
}
