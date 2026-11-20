using MediCare.Application.BackEnd.Dto.AppointmentDto;
using MediCare.Common.Dto;
using MediCare.Common.Interface;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.Extensions.Logging;

namespace MediCare.Application.BackEnd.AppService;

public sealed class UserNotificationService : IUserNotificationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUser;
    private readonly ILogger<UserNotificationService> _logger;

    public UserNotificationService(IUnitOfWork unitOfWork, ICurrentUserService currentUser, ILogger<UserNotificationService> logger)
    {
        _unitOfWork = unitOfWork; _currentUser = currentUser; _logger = logger;
    }

    public async Task NotifyAppointmentAsync(int appointmentId, string type, string title, string message)
    {
        try
        {
            await _unitOfWork.UserNotificationRepository.AddAppointmentNotificationsAsync(appointmentId, type, title, message);
            await _unitOfWork.Commit();
        }
        catch (Exception ex) { _logger.LogWarning(ex, "Could not create notifications for appointment {AppointmentId}.", appointmentId); }
    }

    public async Task NotifyPatientRecordAsync(int medicalRecordId)
    {
        try
        {
            await _unitOfWork.UserNotificationRepository.AddPatientRecordNotificationAsync(medicalRecordId);
            await _unitOfWork.Commit();
        }
        catch (Exception ex) { _logger.LogWarning(ex, "Could not create notification for medical record {MedicalRecordId}.", medicalRecordId); }
    }

    public async Task CreateUpcomingRemindersAsync(DateTime startUtc, DateTime endUtc)
    {
        try
        {
            await _unitOfWork.UserNotificationRepository.CreateUpcomingRemindersAsync(startUtc, endUtc);
            await _unitOfWork.Commit();
        }
        catch (Exception ex) { _logger.LogWarning(ex, "Could not create appointment reminders in the requested window."); }
    }

    public async Task<ResponseDto<List<UserNotificationDto>>> GetMine()
    {
        var response = new ResponseDto<List<UserNotificationDto>>();
        var userId = _currentUser.UserId;
        if (string.IsNullOrWhiteSpace(userId)) return response.GetErrorResponse("Sign in to view notifications.");
        var notifications = await _unitOfWork.UserNotificationRepository.GetForUserAsync(userId);
        return response.GetSuccessResponse(notifications.Select(item => new UserNotificationDto
        {
            Id = item.UserNotificationId, Type = item.Type, Title = item.Title, Message = item.Message,
            RelatedAppointmentId = item.RelatedAppointmentId, CreatedAtUtc = item.CreatedAtUtc, ReadAtUtc = item.ReadAtUtc
        }).ToList(), "Notifications loaded.");
    }

    public async Task<ResponseDto<EmptyResponseDto>> MarkAsRead(long notificationId)
    {
        var response = new ResponseDto<EmptyResponseDto>();
        var userId = _currentUser.UserId;
        if (notificationId <= 0 || string.IsNullOrWhiteSpace(userId))
            return response.GetErrorResponse("Notification not found.");
        if (!await _unitOfWork.UserNotificationRepository.MarkAsReadAsync(notificationId, userId))
            return response.GetErrorResponse("Notification not found.");
        await _unitOfWork.Commit();
        return response.GetSuccessResponse("Notification marked as read.");
    }
}
