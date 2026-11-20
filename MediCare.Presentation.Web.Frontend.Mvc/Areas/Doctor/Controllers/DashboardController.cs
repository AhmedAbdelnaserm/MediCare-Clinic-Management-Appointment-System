using MediCare.Common.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Application.BackEnd.Dto.MedicalRecordDto;
using MediCare.Presentation.Web.Frontend.Mvc.Areas.Doctor.ViewModels;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Doctor.Controllers;

[Area("Doctor")]
[Authorize(Roles = nameof(UserRolesEnum.Doctor))]
public sealed class DashboardController : Controller
{
    private readonly IClinicalRecordService _clinicalRecordService;
    private readonly IClinicalAttachmentService _attachmentService;

    public DashboardController(IClinicalRecordService clinicalRecordService, IClinicalAttachmentService attachmentService)
    {
        _clinicalRecordService = clinicalRecordService;
        _attachmentService = attachmentService;
    }

    public async Task<IActionResult> Index()
    {
        var pending = await _clinicalRecordService.GetAppointmentsAwaitingRecord();
        var records = await _clinicalRecordService.GetDoctorRecords();
        return View(new DoctorWorkspaceViewModel
        {
            AppointmentsAwaitingRecord = pending.Data ?? [],
            RecentRecords = records.Data ?? []
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [RequestSizeLimit(50 * 1024 * 1024)]
    public async Task<IActionResult> CreateRecord(CreateMedicalRecordRequestDto request, IFormFile[]? attachments)
    {
        if (!ModelState.IsValid)
        {
            TempData["RecordError"] = "Check the record details and try again.";
            return RedirectToAction(nameof(Index));
        }

        var response = await _clinicalRecordService.CreateRecord(request);
        var messages = new List<string>();
        if (response.Code == MediCare.Common.Enum.ResultStatusEnum.Success && response.Data is not null)
        {
            foreach (var attachment in attachments ?? [])
            {
                await using var stream = attachment.OpenReadStream();
                var uploaded = await _attachmentService.Upload(response.Data.MedicalRecordId, stream,
                    attachment.FileName, attachment.ContentType, attachment.Length, isDoctor: true);
                if (uploaded.Code != MediCare.Common.Enum.ResultStatusEnum.Success)
                    messages.Add($"{attachment.FileName}: {uploaded.Message}");
            }
        }
        if (messages.Count > 0)
            TempData["RecordError"] = "The record was saved, but some attachments were rejected: " + string.Join("; ", messages);
        TempData[response.Code == MediCare.Common.Enum.ResultStatusEnum.Success ? "RecordMessage" : "RecordError"] = response.Message;
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> DownloadAttachment(int id)
    {
        var result = await _attachmentService.Download(id, isDoctor: true);
        if (result.Code != MediCare.Common.Enum.ResultStatusEnum.Success || result.Data is null)
            return NotFound();
        return File(result.Data.Content, result.Data.ContentType, result.Data.FileName);
    }
}
