using MediCare.Application.BackEnd.Dto.ClinicDoctorDto;
using MediCare.Application.BackEnd.Dto.DoctorDto;
using MediCare.Common.Dto;

namespace MediCare.IApplication.BackEnd.IAppService;

public interface IClinicDoctorAppService
{
    Task<ResponseDto<List<ClinicDoctorDto>>> GetClinicDoctors();
    Task<ResponseDto<List<DoctorResponseDto>>> GetAvailableDoctors();
    Task<ResponseDto<ClinicDoctorDto>> GetClinicDoctor(int clinicDoctorId);
    Task<ResponseDto<EmptyResponseDto>> AddDoctorToClinic(ClinicDoctorDto request);
    Task<ResponseDto<EmptyResponseDto>> UpdateClinicDoctorSchedule(int clinicDoctorId,ClinicDoctorDto request);
    Task<ResponseDto<EmptyResponseDto>> RemoveDoctorFromClinic(int clinicDoctorId);
}