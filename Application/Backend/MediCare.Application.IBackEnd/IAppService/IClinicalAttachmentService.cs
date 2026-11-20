using MediCare.Application.BackEnd.Dto.MedicalRecordDto;
using MediCare.Common.Dto;

namespace MediCare.IApplication.BackEnd.IAppService;

public interface IClinicalAttachmentService
{
    Task<ResponseDto<EmptyResponseDto>> Upload(int medicalRecordId, Stream content, string fileName, string contentType, long declaredLength, bool isDoctor);
    Task<ResponseDto<AttachmentDownloadDto>> Download(int attachmentId, bool isDoctor);
}
