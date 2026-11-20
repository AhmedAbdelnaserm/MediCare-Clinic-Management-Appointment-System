using MediCare.Application.BackEnd.Dto.AppointmentDto;
using MediCare.Common.Dto;

namespace MediCare.IApplication.BackEnd.IAppService;

public interface IUserNotificationService
{
    Task NotifyAppointmentAsync(int appointmentId, string type, string title, string message);
    Task NotifyPatientRecordAsync(int medicalRecordId);
    Task CreateUpcomingRemindersAsync(DateTime startUtc, DateTime endUtc);
    Task<ResponseDto<List<UserNotificationDto>>> GetMine();
    Task<ResponseDto<EmptyResponseDto>> MarkAsRead(long notificationId);
}
