namespace MediCare.Application.Identity.Dto.ClinicAdminDto;

public class ClinicAdminDto
{
    public string UserId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public int ClinicId { get; set; }
    public string ClinicName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}