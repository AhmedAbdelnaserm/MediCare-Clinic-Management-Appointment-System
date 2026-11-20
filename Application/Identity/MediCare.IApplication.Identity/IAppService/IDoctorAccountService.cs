using MediCare.Application.Identity.Dto.DoctorDto;
using MediCare.Common.Dto;

namespace MediCare.IApplication.Identity.IAppService;

public interface IDoctorAccountService
{
    Task<ResponseDto<DoctorAccountDto>> Create(CreateDoctorAccountRequestDto request);
}
