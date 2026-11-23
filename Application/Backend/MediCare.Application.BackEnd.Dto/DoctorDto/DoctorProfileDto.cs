namespace MediCare.Application.BackEnd.Dto.DoctorDto;

public class DoctorProfileDto
{
    public string FullName { get; set; } = string.Empty;
    public int SpecializationId { get; set; }
    public string SpecializationName { get; set; } = string.Empty;
    public string? ProfileImage { get; set; }
    public string? DoctorDegree { get; set; }
    public string EnDescription { get; set; } = string.Empty;
    public List<SpecializationOptionDto> Specializations { get; set; } = new();
}
