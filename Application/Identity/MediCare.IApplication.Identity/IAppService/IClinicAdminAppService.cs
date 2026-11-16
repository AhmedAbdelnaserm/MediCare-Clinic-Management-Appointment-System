using MediCare.Application.Identity.Dto.ClinicAdminDto;
using MediCare.Common.Dto;

namespace MediCare.IApplication.Identity.IAppService;

public interface IClinicAdminAppService
{
    Task<ResponseDto<List<ClinicAdminDto>>> GetClinicAdmins();

    Task<ResponseDto<ClinicAdminDto>> GetClinicAdmin(string userId);

    Task<ResponseDto<EmptyResponseDto>> CreateClinicAdmin(CreateClinicAdminRequestDto request);

    Task<ResponseDto<EmptyResponseDto>> UpdateClinicAdmin(string userId, UpdateClinicAdminRequestDto request);

    Task<ResponseDto<EmptyResponseDto>> SetClinicAdminStatus(string userId, bool isActive);
}