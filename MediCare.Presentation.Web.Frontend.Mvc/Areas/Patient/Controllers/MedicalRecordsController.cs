using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Patient.Controllers;

[Area("Patient")]
[Authorize(Roles = nameof(UserRolesEnum.Patient))]
public sealed class MedicalRecordsController : Controller
{
    private readonly IClinicalRecordService _clinicalRecordService;
    private readonly IClinicalAttachmentService _attachmentService;

    public MedicalRecordsController(IClinicalRecordService clinicalRecordService, IClinicalAttachmentService attachmentService)
    {
        _clinicalRecordService = clinicalRecordService;
        _attachmentService = attachmentService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var response = await _clinicalRecordService.GetMyPatientRecords();
        if (response.Code != ResultStatusEnum.Success)
        {
            TempData["RecordsError"] = response.Message;
            return View(Array.Empty<MediCare.Application.BackEnd.Dto.MedicalRecordDto.MedicalRecordResponseDto>());
        }

        return View(response.Data ?? []);
    }

    [HttpGet]
    public async Task<IActionResult> DownloadAttachment(int id)
    {
        var result = await _attachmentService.Download(id, isDoctor: false);
        if (result.Code != ResultStatusEnum.Success || result.Data is null)
            return NotFound();
        return File(result.Data.Content, result.Data.ContentType, result.Data.FileName);
    }
}
