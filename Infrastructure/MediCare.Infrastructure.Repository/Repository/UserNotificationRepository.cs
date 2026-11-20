using MediCare.Core.Entity.Entity;
using MediCare.Common.Enum;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Infrastructure.Repository.Repository;

public sealed class UserNotificationRepository : IUserNotificationRepository
{
    private readonly ApplicationDbContext _db;
    public UserNotificationRepository(ApplicationDbContext db) => _db = db;

    public async Task AddAppointmentNotificationsAsync(int appointmentId, string type, string title, string message)
    {
        var recipients = await _db.Appointments.AsNoTracking()
            .Where(item => item.AppointmentId == appointmentId)
            .Select(item => new { PatientUserId = item.Patient.UserId, DoctorUserId = item.Slot.ClinicDoctor.Doctor.UserId })
            .FirstOrDefaultAsync();
        if (recipients is null)
            return;
        var now = DateTime.UtcNow;
        var userIds = new[] { recipients.PatientUserId, recipients.DoctorUserId }
            .Where(id => !string.IsNullOrWhiteSpace(id)).Distinct().ToList();
        await _db.UserNotifications.AddRangeAsync(userIds.Select(userId => new UserNotification
        {
            UserId = userId!, Type = type, Title = title.Length > 150 ? title[..150] : title,
            Message = message.Length > 500 ? message[..500] : message,
            RelatedAppointmentId = appointmentId, CreatedAtUtc = now
        }));
    }

    public async Task AddPatientRecordNotificationAsync(int medicalRecordId)
    {
        var patientUserId = await _db.MedicalRecords.AsNoTracking()
            .Where(item => item.MedicalRecordId == medicalRecordId)
            .Select(item => item.Patient.UserId).FirstOrDefaultAsync();
        if (!string.IsNullOrWhiteSpace(patientUserId))
            await _db.UserNotifications.AddAsync(new UserNotification
            {
                UserId = patientUserId, Type = "MedicalRecordCreated", Title = "New medical record",
                Message = "Your doctor added a medical record after your visit.", CreatedAtUtc = DateTime.UtcNow
            });
    }

    public async Task CreateUpcomingRemindersAsync(DateTime startUtc, DateTime endUtc)
    {
        var appointments = await _db.Appointments.AsNoTracking()
            .Where(item => item.AppointmentStatusId == (int)AppointmentStatusEnum.Confirmed &&
                item.StartAt >= startUtc && item.StartAt < endUtc &&
                item.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted)
            .OrderBy(item => item.StartAt).ThenBy(item => item.AppointmentId)
            .Select(item => new
            {
                item.AppointmentId,
                item.StartAt,
                PatientUserId = item.Patient.UserId,
                DoctorUserId = item.Slot.ClinicDoctor.Doctor.UserId
            }).Take(2000).ToListAsync();
        var notifications = new List<UserNotification>();
        foreach (var appointment in appointments)
        {
            var recipients = new[] { appointment.PatientUserId, appointment.DoctorUserId }
                .Where(id => !string.IsNullOrWhiteSpace(id)).Distinct();
            foreach (var recipient in recipients)
            {
                var key = $"appointment-reminder:{appointment.AppointmentId}:{recipient}:{appointment.StartAt.Ticks}";
                if (await _db.UserNotifications.AnyAsync(item => item.DeduplicationKey == key))
                    continue;
                notifications.Add(new UserNotification
                {
                    UserId = recipient!, Type = "AppointmentReminder", Title = "Appointment tomorrow",
                    Message = $"You have an appointment scheduled for {appointment.StartAt:dd MMM yyyy, HH:mm} UTC.",
                    RelatedAppointmentId = appointment.AppointmentId, DeduplicationKey = key, CreatedAtUtc = DateTime.UtcNow
                });
            }
        }
        if (notifications.Count > 0)
            await _db.UserNotifications.AddRangeAsync(notifications);
    }

    public Task<List<UserNotification>> GetForUserAsync(string userId) => _db.UserNotifications.AsNoTracking()
        .Where(item => item.UserId == userId).OrderByDescending(item => item.CreatedAtUtc).Take(100).ToListAsync();

    public async Task<bool> MarkAsReadAsync(long notificationId, string userId)
    {
        var notification = await _db.UserNotifications.FirstOrDefaultAsync(item =>
            item.UserNotificationId == notificationId && item.UserId == userId);
        if (notification is null)
            return false;
        notification.ReadAtUtc ??= DateTime.UtcNow;
        return true;
    }
}
