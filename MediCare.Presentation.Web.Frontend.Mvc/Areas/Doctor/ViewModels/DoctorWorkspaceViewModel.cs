using MediCare.Application.BackEnd.Dto.MedicalRecordDto;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Doctor.ViewModels;

public sealed class DoctorWorkspaceViewModel
{
    public IReadOnlyCollection<DoctorAppointmentDto> AppointmentsAwaitingRecord { get; init; } = Array.Empty<DoctorAppointmentDto>();
    public IReadOnlyCollection<MedicalRecordResponseDto> RecentRecords { get; init; } = Array.Empty<MedicalRecordResponseDto>();
}
