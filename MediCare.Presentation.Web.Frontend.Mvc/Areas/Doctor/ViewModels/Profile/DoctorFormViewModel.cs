using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Doctor.ViewModels.Profile;

public class DoctorFormViewModel
{
    public string FullName { get; set; } = string.Empty;
    [Required]
    public int SpecializationId { get; set; }
    public string? ProfileImage { get; set; }
    public IFormFile? ProfileImageFile { get; set; }
    [StringLength(150)]
    public string? DoctorDegree { get; set; }
    [Required]
    [StringLength(500)]
    public string EnDescription { get; set; } = string.Empty;
    public List<SelectListItem> Specializations { get; set; } = new();
}
