using MediCare.Application.BackEnd.Dto.AppointmentDto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Patient.ViewModels;

public sealed class AppointmentsViewModel
{
    public int? DoctorId { get; init; }
    public IReadOnlyCollection<SelectListItem> Doctors { get; init; } = Array.Empty<SelectListItem>();
    public IReadOnlyCollection<AvailableSlotDto> AvailableSlots { get; init; } = Array.Empty<AvailableSlotDto>();
    public IReadOnlyCollection<PatientAppointmentDto> MyAppointments { get; init; } = Array.Empty<PatientAppointmentDto>();
}
