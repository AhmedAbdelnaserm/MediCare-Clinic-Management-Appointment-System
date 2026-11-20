using MediCare.Application.BackEnd.Dto.MedicalRecordDto;
using MediCare.Common.Dto;

namespace MediCare.IApplication.BackEnd.IAppService;

public interface IClinicalRecordService
{
    Task<ResponseDto<List<DoctorAppointmentDto>>> GetAppointmentsAwaitingRecord();
    Task<ResponseDto<List<MedicalRecordResponseDto>>> GetDoctorRecords();
    Task<ResponseDto<List<MedicalRecordResponseDto>>> GetMyPatientRecords();
    Task<ResponseDto<MedicalRecordResponseDto>> CreateRecord(CreateMedicalRecordRequestDto request);
}
