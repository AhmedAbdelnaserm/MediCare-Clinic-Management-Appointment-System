using MediCare.Application.BackEnd.Dto.AppointmentDto;
using MediCare.Common.Dto;

namespace MediCare.IApplication.BackEnd.IAppService;

public interface IAppointmentService
{
    Task<ResponseDto<List<AvailableSlotDto>>> GetAvailableSlots(int? doctorId);
    Task<ResponseDto<List<PatientAppointmentDto>>> GetMyAppointments();
    Task<ResponseDto<PatientAppointmentDto>> Book(int slotId);
    Task<ResponseDto<EmptyResponseDto>> Reschedule(int appointmentId, int slotId);
    Task<ResponseDto<EmptyResponseDto>> Cancel(int appointmentId, string? reason);
}
