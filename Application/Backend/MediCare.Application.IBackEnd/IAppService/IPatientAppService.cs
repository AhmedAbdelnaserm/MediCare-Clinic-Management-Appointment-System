using MediCare.Application.BackEnd.Dto.Dto.Paitient;
using MediCare.Common.Dto;

namespace MediCare.IApplication.BackEnd.IAppService
{
    public interface IPatientAppService
    {
        Task<ResponseDto<IEnumerable<PatientDto>>> GetAllAsync();
        Task<ResponseDto<PatientDto>> GetByIdAsync(int patientId);
        Task<ResponseDto<PatientDto>> GetMyProfileAsync(string currentUserId);
        Task<ResponseDto<PatientDto>> CreateAsync(CreatePatientDto dto, string currentUserId);
        Task<ResponseDto<PatientDto>> UpdateAsync(UpdatePatientDto dto, string currentUserId);
        Task<ResponseDto<bool>> DeleteAsync(int patientId, string currentUserId);
    }
}
