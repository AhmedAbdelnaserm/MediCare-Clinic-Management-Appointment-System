using MediCare.Application.BackEnd.Dto.DoctorDto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Patient.ViewModels;

public sealed class DoctorDirectoryViewModel
{
    public int? SpecializationId { get; init; }
    public IReadOnlyCollection<SelectListItem> Specializations { get; init; }
        = Array.Empty<SelectListItem>();
    public IReadOnlyCollection<DoctorResponseDto> Doctors { get; init; }
        = Array.Empty<DoctorResponseDto>();
}
