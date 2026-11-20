using MediCare.Core.Entity.Entity;

namespace MediCare.Core.IRepository.IRepository;

public interface IUserNotificationRepository
{
    Task AddAppointmentNotificationsAsync(int appointmentId, string type, string title, string message);
    Task AddPatientRecordNotificationAsync(int medicalRecordId);
    Task CreateUpcomingRemindersAsync(DateTime startUtc, DateTime endUtc);
    Task<List<UserNotification>> GetForUserAsync(string userId);
    Task<bool> MarkAsReadAsync(long notificationId, string userId);
}
