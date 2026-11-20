using MediCare.Application.BackEnd.Dto.AppointmentDto;
using MediCare.Common.Dto;

namespace MediCare.IApplication.BackEnd.IAppService;

public interface IClinicScheduleService
{
    Task<ResponseDto<List<ClinicDoctorScheduleSummaryDto>>> GetClinicDoctorLinks();
    Task<ResponseDto<ClinicDoctorScheduleDetailsDto>> GetClinicDoctorSchedule(int clinicDoctorId);
    Task<ResponseDto<int>> CreateClinicDoctorLink(CreateClinicDoctorScheduleDto request);
    Task<ResponseDto<EmptyResponseDto>> ReplaceWorkingHours(int clinicDoctorId, ReplaceWorkingHoursDto request);
    Task<ResponseDto<GeneratedSlotsDto>> GenerateSlots(int clinicDoctorId, GenerateSlotsDto request);
    Task<ResponseDto<List<ScheduleExceptionDto>>> GetScheduleExceptions(int clinicDoctorId, DateOnly startDate, DateOnly endDate);
    Task<ResponseDto<EmptyResponseDto>> SaveScheduleException(int clinicDoctorId, SaveScheduleExceptionDto request);
    Task<ResponseDto<EmptyResponseDto>> DeleteScheduleException(int clinicDoctorId, int exceptionId);
}
