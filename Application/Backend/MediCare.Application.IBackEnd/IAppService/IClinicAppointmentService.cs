using MediCare.Application.BackEnd.Dto.AppointmentDto;
using MediCare.Common.Dto;

namespace MediCare.IApplication.BackEnd.IAppService;

public interface IClinicAppointmentService
{
    Task<ResponseDto<List<ClinicAppointmentDto>>> GetAppointments();
    Task<ResponseDto<EmptyResponseDto>> Cancel(int appointmentId, string? reason);
}
