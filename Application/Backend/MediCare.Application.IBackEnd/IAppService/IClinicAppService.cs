using MediCare.Application.BackEnd.Dto.ClinicDto;
using MediCare.Common.Dto;

namespace MediCare.IApplication.BackEnd.IAppService
{
    public interface IClinicAppService
    {
        Task<ResponseDto<ClinicDto>> GetClinic(int clinicId);
        Task<ResponseDto<List<TextValueBindingResponseDto>>> GetClinics();
        Task<ResponseDto<List<TextValueBindingResponseDto>>> GetClinicsByAreaId(int areaId);
        Task<ResponseDto<List<ClinicDto>>> GetClinicsForManagement();
        Task<ResponseDto<EmptyResponseDto>> CreateClinic(CreateClinicRequestDto clinicDto);
        Task<ResponseDto<EmptyResponseDto>> UpdateClinic(int clinicId, UpdateClinicRequestDto clinicDto);
        Task<ResponseDto<EmptyResponseDto>> DeleteClinic(int clinicId);
        Task<ResponseDto<ClinicDto>> GetMyClinic();
        Task<ResponseDto<EmptyResponseDto>> UpdateMyClinic(UpdateClinicRequestDto clinicDto);
    }
}
