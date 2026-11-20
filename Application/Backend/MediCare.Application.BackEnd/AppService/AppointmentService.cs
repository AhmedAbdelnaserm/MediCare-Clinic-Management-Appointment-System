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

public sealed class AppointmentService : BaseAppService, IAppointmentService
{
    private readonly IUserNotificationService _notifications;
    public AppointmentService(
                ILocalizationService localization,
        ILogger<AppointmentService> logger,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUser,
        IUserNotificationService notifications)
        : base(localization, logger, unitOfWork, currentUser) => _notifications = notifications;

    public async Task<ResponseDto<List<AvailableSlotDto>>> GetAvailableSlots(int? doctorId)
    {
        var response = new ResponseDto<List<AvailableSlotDto>>();
        if (doctorId is <= 0)
            return response.GetErrorResponse(Localization.InvalidData);

        var slots = await UnitOfWork.AppointmentRepository.GetAvailableSlotsAsync(doctorId);
        var data = slots.Select(slot => new AvailableSlotDto
        {
            SlotId = slot.SlotId,
            DoctorId = slot.ClinicDoctor.DoctorId,
            DoctorName = slot.ClinicDoctor.Doctor.EnName,
            ClinicName = slot.ClinicDoctor.Clinic.EnName,
            ClinicAddress = slot.ClinicDoctor.Clinic.Address,
            StartAt = slot.SlotDateTime,
            EndAt = slot.SlotDateTime.AddMinutes(slot.ClinicDoctor.ConsultationDurationMinutes),
            ConsultationFee = slot.ClinicDoctor.Doctor.ConsultationFee
        }).ToList();

        return response.GetSuccessResponse(data, Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<List<PatientAppointmentDto>>> GetMyAppointments()
    {
        var response = new ResponseDto<List<PatientAppointmentDto>>();
        var userId = CurrentUser.UserId;
        if (string.IsNullOrWhiteSpace(userId))
            return response.GetErrorResponse(Localization.InvalidRequest);

        var patient = await UnitOfWork.PatientRepository.GetByUserId(userId);
        if (patient is null)
            return response.GetErrorResponse(Localization.NoDataFound);

        var appointments = await UnitOfWork.AppointmentRepository.GetPatientAppointmentsAsync(patient.PatientId);
        var data = appointments.Select(ToPatientAppointment).ToList();
        return response.GetSuccessResponse(data, Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<PatientAppointmentDto>> Book(int slotId)
    {
        var response = new ResponseDto<PatientAppointmentDto>();
        var userId = CurrentUser.UserId;
        if (slotId <= 0 || string.IsNullOrWhiteSpace(userId))
            return response.GetErrorResponse(Localization.InvalidData);

        var patient = await UnitOfWork.PatientRepository.GetByUserId(userId);
        if (patient is null)
            return response.GetErrorResponse(Localization.NoDataFound);

        try
        {
            var appointment = await UnitOfWork.AppointmentRepository.TryBookSlotAsync(
                slotId, patient.PatientId, userId);

            if (appointment is null)
                return response.GetErrorResponse(
                    "This appointment time is no longer available. Choose another time.",
                    ResultStatusEnum.Duplicated);

            await _notifications.NotifyAppointmentAsync(appointment.AppointmentId, "Booked", "Appointment confirmed",
                $"An appointment was booked for {appointment.StartAt:dd MMM yyyy, HH:mm} UTC.");
            return response.GetSuccessResponse(ToPatientAppointment(appointment), Localization.GeneralSuccess);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Failed to book slot {SlotId} for patient {PatientId}.", slotId, patient.PatientId);
            return response.GetErrorResponse(Localization.GeneralError);
        }
    }

    public async Task<ResponseDto<EmptyResponseDto>> Cancel(int appointmentId, string? reason)
    {
        var response = new ResponseDto<EmptyResponseDto>();
        var userId = CurrentUser.UserId;
        if (appointmentId <= 0 || string.IsNullOrWhiteSpace(userId))
            return response.GetErrorResponse(Localization.InvalidData);
        if (reason?.Length > 500)
            return response.GetErrorResponse(Localization.InvalidData);

        var patient = await UnitOfWork.PatientRepository.GetByUserId(userId);
        if (patient is null)
            return response.GetErrorResponse(Localization.NoDataFound);

        var cancelled = await UnitOfWork.AppointmentRepository.TryCancelAsync(
            appointmentId, patient.PatientId, userId, string.IsNullOrWhiteSpace(reason) ? null : reason.Trim());

        if (!cancelled)
            return response.GetErrorResponse("This appointment cannot be cancelled because it has started or is no longer active.");
        await _notifications.NotifyAppointmentAsync(appointmentId, "Cancelled", "Appointment cancelled", "An appointment was cancelled.");
        return response.GetSuccessResponse(Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<EmptyResponseDto>> Reschedule(int appointmentId, int slotId)
    {
        var response = new ResponseDto<EmptyResponseDto>();
        var userId = CurrentUser.UserId;
        if (appointmentId <= 0 || slotId <= 0 || string.IsNullOrWhiteSpace(userId))
            return response.GetErrorResponse(Localization.InvalidData);

        var patient = await UnitOfWork.PatientRepository.GetByUserId(userId);
        if (patient is null)
            return response.GetErrorResponse(Localization.NoDataFound);

        try
        {
            var changed = await UnitOfWork.AppointmentRepository.TryRescheduleAsync(
                appointmentId, slotId, patient.PatientId, userId);
            if (changed)
                await _notifications.NotifyAppointmentAsync(appointmentId, "Rescheduled", "Appointment rescheduled", "An appointment time was changed.");
            return changed
                ? response.GetSuccessResponse(Localization.GeneralSuccess)
                : response.GetErrorResponse("The appointment or selected time is no longer available.", ResultStatusEnum.Duplicated);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Failed to reschedule appointment {AppointmentId}.", appointmentId);
            return response.GetErrorResponse(Localization.GeneralError);
        }
    }

    private static PatientAppointmentDto ToPatientAppointment(Appointment appointment)
    {
        var clinicDoctor = appointment.Slot.ClinicDoctor;
        var status = Enum.IsDefined(typeof(AppointmentStatusEnum), appointment.AppointmentStatusId)
            ? ((AppointmentStatusEnum)appointment.AppointmentStatusId).ToString()
            : "Unknown";

        return new PatientAppointmentDto
        {
            AppointmentId = appointment.AppointmentId,
            SlotId = appointment.SlotId,
            DoctorId = clinicDoctor.DoctorId,
            DoctorName = clinicDoctor.Doctor.EnName,
            ClinicName = clinicDoctor.Clinic.EnName,
            ClinicAddress = clinicDoctor.Clinic.Address,
            StartAt = appointment.StartAt,
            EndAt = appointment.EndAt,
            StatusId = appointment.AppointmentStatusId,
            Status = status,
            ConsultationFee = clinicDoctor.Doctor.ConsultationFee
        };
    }
}
