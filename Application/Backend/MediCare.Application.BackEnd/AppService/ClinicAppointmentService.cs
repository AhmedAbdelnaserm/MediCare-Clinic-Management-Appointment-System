using MediCare.Application.BackEnd.Base;
using MediCare.Application.BackEnd.Dto.AppointmentDto;
using MediCare.Application.BackEnd.Localization;
using MediCare.Common.Dto;
using MediCare.Common.Enum;
using MediCare.Common.Interface;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.Extensions.Logging;

namespace MediCare.Application.BackEnd.AppService;

public sealed class ClinicAppointmentService : BaseAppService, IClinicAppointmentService
{
    private readonly IUserNotificationService _notifications;
    public ClinicAppointmentService(
                ILocalizationService localization,
        ILogger<ClinicAppointmentService> logger,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUser,
        IUserNotificationService notifications)
        : base(localization, logger, unitOfWork, currentUser) => _notifications = notifications;

    public async Task<ResponseDto<List<ClinicAppointmentDto>>> GetAppointments()
    {
        var response = new ResponseDto<List<ClinicAppointmentDto>>();
        var clinicId = await GetCurrentClinicId();
        if (clinicId is null)
            return response.GetErrorResponse(Localization.NoDataFound);

        var appointments = await UnitOfWork.ClinicAppointmentRepository.GetClinicAppointmentsAsync(clinicId.Value);
        var data = appointments.Select(appointment => new ClinicAppointmentDto
        {
            AppointmentId = appointment.AppointmentId,
            PatientName = appointment.Patient.User?.FullName ?? "Patient",
            DoctorName = appointment.Slot.ClinicDoctor.Doctor.EnName,
            ClinicName = appointment.Slot.ClinicDoctor.Clinic.EnName,
            StartAt = appointment.StartAt,
            EndAt = appointment.EndAt,
            StatusId = appointment.AppointmentStatusId,
            Status = Enum.IsDefined(typeof(AppointmentStatusEnum), appointment.AppointmentStatusId)
                ? ((AppointmentStatusEnum)appointment.AppointmentStatusId).ToString()
                : "Unknown",
            ConsultationFee = appointment.Slot.ClinicDoctor.Doctor.ConsultationFee
        }).ToList();

        return response.GetSuccessResponse(data, Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<EmptyResponseDto>> Cancel(int appointmentId, string? reason)
    {
        var response = new ResponseDto<EmptyResponseDto>();
        if (appointmentId <= 0 || reason?.Length > 500)
            return response.GetErrorResponse(Localization.InvalidData);

        var userId = CurrentUser.UserId;
        var clinicId = await GetCurrentClinicId();
        if (string.IsNullOrWhiteSpace(userId) || clinicId is null)
            return response.GetErrorResponse(Localization.InvalidRequest);

        try
        {
            var cancelled = await UnitOfWork.ClinicAppointmentRepository.TryCancelAsync(
                appointmentId, clinicId.Value, userId, string.IsNullOrWhiteSpace(reason) ? null : reason.Trim());
            if (!cancelled)
                return response.GetErrorResponse("This appointment cannot be cancelled because it has started or is no longer active.");
            await _notifications.NotifyAppointmentAsync(appointmentId, "CancelledByClinic", "Appointment cancelled by clinic",
                string.IsNullOrWhiteSpace(reason) ? "The clinic cancelled your appointment." : $"The clinic cancelled your appointment: {reason.Trim()}");
            return response.GetSuccessResponse(Localization.GeneralSuccess);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Clinic admin {UserId} failed to cancel appointment {AppointmentId}.", userId, appointmentId);
            return response.GetErrorResponse(Localization.GeneralError);
        }
    }

    private async Task<int?> GetCurrentClinicId()
    {
        var userId = CurrentUser.UserId;
        if (string.IsNullOrWhiteSpace(userId))
            return null;

        var staff = await UnitOfWork.ClinicStaffRepository.GetByUserId(userId);
        return staff?.ClinicId;
    }
}
