namespace MediCare.Core.Entity.Entity;

public sealed class UserNotification
{
    public long UserNotificationId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public int? RelatedAppointmentId { get; set; }
    public string? DeduplicationKey { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? ReadAtUtc { get; set; }
}
