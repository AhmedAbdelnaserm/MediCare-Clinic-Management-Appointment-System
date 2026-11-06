using MediCare.Common.Dto;
using MediCare.Application.BackEnd.Dto.Dto;

namespace MediCare.IApplication.BackEnd.IAppService
{
    public interface IDoctorService
    {
        Task<ResponseDto<EmptyResponseDto>> CreateDoctor(CreateDoctorRequestDto doctorRequestDto);
        Task<ResponseDto<EmptyResponseDto>> UpdateDoctor(int doctorId, UpdateDoctorRequestDto? doctorRequestDto);
        Task<ResponseDto<EmptyResponseDto>> DeleteDoctor(int doctorId);
        Task<ResponseDto<DoctorResponseDto>> GetDoctorById(int doctorId);
        Task<ResponseDto<List<DoctorResponseDto>>> GetDoctors();
        Task<ResponseDto<List<DoctorResponseDto>>> GetDoctorsBySpecializationId(int specializationId);


        
    }
}
