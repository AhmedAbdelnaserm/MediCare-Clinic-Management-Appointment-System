namespace MediCare.Application.BackEnd.Dto.MedicalRecordDto;

public sealed class MedicalRecordAttachmentDto
{
    public int AttachmentId { get; set; }
    public string FileName { get; set; } = string.Empty;
}

public sealed class AttachmentDownloadDto
{
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public Stream Content { get; set; } = Stream.Null;
}
