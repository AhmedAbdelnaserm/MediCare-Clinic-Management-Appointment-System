using System.ComponentModel.DataAnnotations;

namespace MediCare.Application.Identity.Dto.ClinicAdminDto;

public class UpdateClinicAdminRequestDto
{
    [Required, MaxLength(150)]
    public string FullName { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    [Range(1, int.MaxValue)]
    public int ClinicId { get; set; }
}