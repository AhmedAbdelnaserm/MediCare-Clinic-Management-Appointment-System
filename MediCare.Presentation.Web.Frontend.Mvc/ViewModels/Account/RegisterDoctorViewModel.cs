using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MediCare.Presentation.Web.Frontend.Mvc.ViewModels.Account;

public class RegisterDoctorViewModel
{
    [Required]
    [StringLength(150)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public string? PhoneNumber { get; set; }

    [Required]
    public int SpecializationId { get; set; }

    [StringLength(150)]
    public string? DoctorDegree { get; set; }

    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;

    public List<SelectListItem> Specializations { get; set; } = [];
}