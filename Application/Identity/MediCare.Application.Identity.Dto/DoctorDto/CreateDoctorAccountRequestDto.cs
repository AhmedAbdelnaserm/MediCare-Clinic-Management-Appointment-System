using System.ComponentModel.DataAnnotations;

namespace MediCare.Application.Identity.Dto.DoctorDto;

public sealed class CreateDoctorAccountRequestDto
{
    [Required, StringLength(200)]
    public string FullName { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(256)]
    public string Email { get; set; } = string.Empty;

    [Phone, StringLength(30)]
    public string? PhoneNumber { get; set; }

    [Required, MinLength(8), StringLength(128)]
    public string Password { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int SpecializationId { get; set; }

    [Range(0, 1000000)]
    public decimal ConsultationFee { get; set; }

    [Required, StringLength(200)]
    public string EnName { get; set; } = string.Empty;

    [Required, StringLength(4000)]
    public string EnDescription { get; set; } = string.Empty;

    [StringLength(500)]
    public string? DoctorDegree { get; set; }

    [Url, StringLength(1000)]
    public string? ProfileImage { get; set; }
}

public sealed class DoctorAccountDto
{
    public string UserId { get; set; } = string.Empty;
    public int DoctorId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
