using MediCare.Application.BackEnd.Dto.MedicalRecordDto;
using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Presentation.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.BackEnd.Api.Controllers;

[ApiController]
[Route("api/medical-records")]
[Authorize]
public sealed class MedicalRecordsController : ControllerBase
{
    private readonly IClinicalRecordService _clinicalRecordService;
    private readonly IClinicalAttachmentService _attachmentService;

    public MedicalRecordsController(IClinicalRecordService clinicalRecordService, IClinicalAttachmentService attachmentService)
    {
        _clinicalRecordService = clinicalRecordService;
        _attachmentService = attachmentService;
    }

    [HttpGet("patient/mine")]
    [Authorize(Roles = nameof(UserRolesEnum.Patient))]
    public async Task<IActionResult> GetMyRecords() =>
        this.ToHttpResult(await _clinicalRecordService.GetMyPatientRecords());

    [HttpGet("doctor/mine")]
    [Authorize(Roles = nameof(UserRolesEnum.Doctor))]
    public async Task<IActionResult> GetDoctorRecords() =>
        this.ToHttpResult(await _clinicalRecordService.GetDoctorRecords());

    [HttpGet("doctor/appointments-awaiting-record")]
    [Authorize(Roles = nameof(UserRolesEnum.Doctor))]
    public async Task<IActionResult> GetAppointmentsAwaitingRecord() =>
        this.ToHttpResult(await _clinicalRecordService.GetAppointmentsAwaitingRecord());

    [HttpPost]
    [Authorize(Roles = nameof(UserRolesEnum.Doctor))]
    public async Task<IActionResult> Create([FromBody] CreateMedicalRecordRequestDto request) =>
        this.ToHttpResult(await _clinicalRecordService.CreateRecord(request));

    [HttpPost("{medicalRecordId:int}/attachments")]
    [RequestSizeLimit(11 * 1024 * 1024)]
    public async Task<IActionResult> UploadAttachment(int medicalRecordId, IFormFile file)
    {
        if (file is null)
            return BadRequest();
        var isDoctor = User.IsInRole(nameof(UserRolesEnum.Doctor));
        if (!isDoctor && !User.IsInRole(nameof(UserRolesEnum.Patient)))
            return Forbid();
        await using var stream = file.OpenReadStream();
        var result = await _attachmentService.Upload(medicalRecordId, stream, file.FileName,
            file.ContentType, file.Length, isDoctor);
        return this.ToHttpResult(result);
    }

    [HttpGet("attachments/{attachmentId:int}")]
    public async Task<IActionResult> DownloadAttachment(int attachmentId)
    {
        var isDoctor = User.IsInRole(nameof(UserRolesEnum.Doctor));
        if (!isDoctor && !User.IsInRole(nameof(UserRolesEnum.Patient)))
            return Forbid();
        var result = await _attachmentService.Download(attachmentId, isDoctor);
        if (result.Code != ResultStatusEnum.Success || result.Data is null)
            return NotFound();
        return File(result.Data.Content, result.Data.ContentType, result.Data.FileName);
    }
}
