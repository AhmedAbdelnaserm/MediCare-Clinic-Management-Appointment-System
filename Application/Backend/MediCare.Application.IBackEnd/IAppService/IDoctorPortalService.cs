using MediCare.Application.BackEnd.Dto.DoctorDto;
using MediCare.Common.Dto;

namespace MediCare.IApplication.BackEnd.IAppService;

public interface IDoctorPortalService
{
    Task<ResponseDto<DoctorProfileDto>> GetMyProfile();
    Task<ResponseDto<DoctorProfileDto>> UpdateMyProfile(UpdateDoctorProfileRequestDto request, Stream? imageStream, string? imageFileName, long imageLength);
    Task<ResponseDto<List<DoctorClinicSummaryDto>>> GetMyClinics();
}

