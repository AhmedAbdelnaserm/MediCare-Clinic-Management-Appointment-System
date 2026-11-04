using MediCare.Common.Dto;
using MediCare.Application.BackEnd.Dto.Dto;

namespace MediCare.IApplication.BackEnd.IAppService
{
    public interface IDoctorService
    {
        Task<ResponseDto<EmptyResponseDto>> CreateDoctor(DoctorRequestDto doctorRequestDto);
        Task<ResponseDto<EmptyResponseDto>> UpdateDoctor(DoctorRequestDto doctorRequestDto);
        Task<ResponseDto<bool>> DeleteDoctor(int doctorId);
        Task<ResponseDto<DoctorResponseDto>> GetDoctorById(int doctorId);
        Task<ResponseDto<List<DoctorResponseDto>>> GetDoctors();
        Task<ResponseDto<List<DoctorResponseDto>>> GetDoctorsBySpecializationId(int specializationId);
        Task<ResponseDto<List<DoctorResponseDto>>> GetDoctorsByClinicId(int clinicId);
        Task<ResponseDto<List<DoctorResponseDto>>> GetDoctorsByClinicIdAndSpecializationId(int clinicId, int specializationId);
        Task<ResponseDto<List<AppointmentResponseDto>>> GetAppointmentsByDoctorId(int doctorId);
        Task<ResponseDto<List<SlotResponseDto>>> GetSlotsByDoctorId(int doctorId);

        
    }
}
