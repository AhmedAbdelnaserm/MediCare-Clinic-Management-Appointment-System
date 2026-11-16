
using System.ComponentModel.DataAnnotations;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.SuperAdmin.ViewModels;

public class ClinicFormViewModel
{
    [Required]
    public string EnName { get; set; } = string.Empty;

    public string EnDescription { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please select a city.")]
    public int CityId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please select an area.")]
    public int AreaId { get; set; }
}
