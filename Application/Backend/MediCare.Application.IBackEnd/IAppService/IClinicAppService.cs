
using MediCare.Common.Dto;

namespace MediCare.IApplication.BackEnd.IAppService
{
    public interface IClinicAppService
    {
        Task<ResponseDto<ClinicDto>> GetClinic(int clinicId);
        Task<ResponseDto<List<TextValueBindingResponseDto>>> GetClinics();
        Task<ResponseDto<List<TextValueBindingResponseDto>>> GetClinicsByAreaId(int areaId);

        Task<ResponseDto<EmptyResponseDto>> CreateClinic(CreateClinicRequestDto clinicDto);
        Task<ResponseDto<EmptyResponseDto>> UpdateClinic(int clinicId, CreateClinicRequestDto clinicDto);
        Task<ResponseDto<EmptyResponseDto>> DeleteClinic(int clinicId);
    }
}
