using MediCare.Application.BackEnd.Dto.MedicalRecordDto;
using MediCare.Application.BackEnd.Localization;
using MediCare.Application.BackEnd.Storage;
using MediCare.Common.Dto;
using MediCare.Common.Interface;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.Extensions.Logging;

namespace MediCare.Application.BackEnd.AppService;

public sealed class ClinicalAttachmentService : IClinicalAttachmentService
{
    private const int MaxFileBytes = 10 * 1024 * 1024;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUser;
    private readonly IPrivateAttachmentStorage _storage;
    private readonly ILogger<ClinicalAttachmentService> _logger;

    public ClinicalAttachmentService(IUnitOfWork unitOfWork, ICurrentUserService currentUser,
        IPrivateAttachmentStorage storage, ILogger<ClinicalAttachmentService> logger)
    {
        _unitOfWork = unitOfWork;
        _currentUser = currentUser;
        _storage = storage;
        _logger = logger;
    }

    public async Task<ResponseDto<EmptyResponseDto>> Upload(int medicalRecordId, Stream content, string fileName,
        string contentType, long declaredLength, bool isDoctor)
    {
        var response = new ResponseDto<EmptyResponseDto>();
        var userId = _currentUser.UserId;
        var extension = Path.GetExtension(fileName).ToLowerInvariant();
        var expectedType = extension switch
        {
            ".pdf" => "application/pdf",
            ".png" => "image/png",
            ".jpg" or ".jpeg" => "image/jpeg",
            _ => null
        };
        if (string.IsNullOrWhiteSpace(userId) || medicalRecordId <= 0 || expectedType is null ||
            !string.Equals(expectedType, contentType, StringComparison.OrdinalIgnoreCase) ||
            declaredLength is <= 0 or > MaxFileBytes)
            return response.GetErrorResponse("Only PDF, JPEG, and PNG files up to 10 MB are accepted.");

        var record = await _unitOfWork.ClinicalRecordRepository.GetRecordForAttachmentAsync(medicalRecordId, userId, isDoctor);
        if (record is null)
            return response.GetErrorResponse("The medical record was not found or is not available to this account.");

        await using var buffer = new MemoryStream();
        var chunk = new byte[81920];
        int read;
        while ((read = await content.ReadAsync(chunk)) > 0)
        {
            if (buffer.Length + read > MaxFileBytes)
                return response.GetErrorResponse("File exceeds the 10 MB limit.");
            await buffer.WriteAsync(chunk.AsMemory(0, read));
        }
        var bytes = buffer.ToArray();
        if (bytes.LongLength != declaredLength || !HasValidSignature(bytes, extension))
            return response.GetErrorResponse("The file contents do not match the selected file type.");

        string storageKey;
        await using (var upload = new MemoryStream(bytes, writable: false))
            storageKey = await _storage.SaveAsync(upload, extension);
        try
        {
            var safeName = Path.GetFileName(fileName.Replace('\\', '/'));
            safeName = new string(safeName.Where(character => !char.IsControl(character)).ToArray()).Trim();
            if (string.IsNullOrWhiteSpace(safeName))
                safeName = $"clinical-file{extension}";
            if (safeName.Length > 180)
                safeName = safeName[^180..];
            await _unitOfWork.ClinicalRecordRepository.AddAttachmentAsync(new UploadedAttachment
            {
                MedicalRecordId = record.MedicalRecordId,
                FileName = safeName,
                FilePath = storageKey,
                ContentType = expectedType,
                FileSize = bytes.LongLength,
                AttachmentTypeId = 1,
                CreatorUserId = userId,
                CreationTime = DateTime.UtcNow
            });
            if (await _unitOfWork.Commit() <= 0)
                throw new InvalidOperationException("Attachment metadata was not saved.");
            return response.GetSuccessResponse("Attachment uploaded successfully.");
        }
        catch (Exception ex)
        {
            try { await _storage.DeleteAsync(storageKey); }
            catch (Exception cleanupException) { _logger.LogWarning(cleanupException, "Unable to clean up failed private attachment write."); }
            _logger.LogError(ex, "Failed to save attachment metadata for medical record {MedicalRecordId}.", medicalRecordId);
            return response.GetErrorResponse("The attachment could not be saved.");
        }
    }

    public async Task<ResponseDto<AttachmentDownloadDto>> Download(int attachmentId, bool isDoctor)
    {
        var response = new ResponseDto<AttachmentDownloadDto>();
        var userId = _currentUser.UserId;
        if (string.IsNullOrWhiteSpace(userId) || attachmentId <= 0)
            return response.GetErrorResponse("Attachment not found.");
        var attachment = await _unitOfWork.ClinicalRecordRepository.GetOwnedAttachmentAsync(attachmentId, userId, isDoctor);
        if (attachment is null)
            return response.GetErrorResponse("Attachment not found.");
        try
        {
            var stream = await _storage.OpenReadAsync(attachment.FilePath);
            return response.GetSuccessResponse(new AttachmentDownloadDto
            {
                FileName = attachment.FileName,
                ContentType = attachment.ContentType,
                Content = stream
            }, "Attachment loaded.");
        }
        catch (FileNotFoundException ex)
        {
            _logger.LogError(ex, "Private attachment {AttachmentId} is missing from storage.", attachmentId);
            return response.GetErrorResponse("The attachment file is currently unavailable.");
        }
    }

    private static bool HasValidSignature(byte[] bytes, string extension) => extension switch
    {
        ".pdf" => bytes.Length >= 5 && bytes.AsSpan(0, 5).SequenceEqual("%PDF-"u8),
        ".png" => bytes.Length >= 8 && bytes.AsSpan(0, 8).SequenceEqual(new byte[] { 137, 80, 78, 71, 13, 10, 26, 10 }),
        ".jpg" or ".jpeg" => bytes.Length >= 3 && bytes[0] == 0xFF && bytes[1] == 0xD8 && bytes[2] == 0xFF,
        _ => false
    };
}
