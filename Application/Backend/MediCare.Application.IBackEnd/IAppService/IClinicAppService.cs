
using MediCare.Common.Dto;

namespace MediCare.IApplication.BackEnd.IAppService
{
    public interface IClinicAppService
    {
        Task<ResponseDto<TextValueBindingResponseDto>> GetClinic(int clinicId);
        Task<ResponseDto<List<TextValueBindingResponseDto>>> GetClinics();
        Task<ResponseDto<List<TextValueBindingResponseDto>>> GetClinicsByAreaId(int areaId);
        Task<ResponseDto<ClinicDto>> GetClinicDetails(int clinicId);

        Task<ResponseDto<ClinicDto>> CreateClinic(SaveClinicDto clinicDto);
        Task<ResponseDto<ClinicDto>> UpdateClinic(int clinicId, SaveClinicDto clinicDto);
        Task<ResponseDto<bool>> DeleteClinic(int clinicId);
    }
}
