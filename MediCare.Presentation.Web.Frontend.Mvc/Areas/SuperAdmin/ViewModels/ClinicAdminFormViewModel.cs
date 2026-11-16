using System.ComponentModel.DataAnnotations;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.SuperAdmin.ViewModels;

public class ClinicAdminFormViewModel
{
    [Required]
    public string FullName { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public string? PhoneNumber { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please select a clinic.")]
    public int ClinicId { get; set; }

    [Required, MinLength(8)]
    public string? Password { get; set; }
}