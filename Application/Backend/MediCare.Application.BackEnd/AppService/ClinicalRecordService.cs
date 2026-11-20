using MediCare.Application.BackEnd.Base;
using MediCare.Application.BackEnd.Dto.MedicalRecordDto;
using MediCare.Application.BackEnd.Localization;
using MediCare.Common.Dto;
using MediCare.Common.Enum;
using MediCare.Common.Interface;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.Extensions.Logging;

namespace MediCare.Application.BackEnd.AppService;

public sealed class ClinicalRecordService : BaseAppService, IClinicalRecordService
{
    private readonly IUserNotificationService _notifications;
    public ClinicalRecordService(
                ILocalizationService localization,
        ILogger<ClinicalRecordService> logger,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUser,
        IUserNotificationService notifications)
        : base(localization, logger, unitOfWork, currentUser) => _notifications = notifications;

    public async Task<ResponseDto<List<DoctorAppointmentDto>>> GetAppointmentsAwaitingRecord()
    {
        var response = new ResponseDto<List<DoctorAppointmentDto>>();
        var userId = CurrentUser.UserId;
        if (string.IsNullOrWhiteSpace(userId))
            return response.GetErrorResponse(Localization.InvalidRequest);

        var appointments = await UnitOfWork.ClinicalRecordRepository.GetAppointmentsAwaitingRecordAsync(userId);
        var data = appointments.Select(appointment => new DoctorAppointmentDto
        {
            AppointmentId = appointment.AppointmentId,
            PatientId = appointment.PatientId,
            PatientName = appointment.Patient.User?.FullName ?? "Patient",
            StartAt = appointment.StartAt,
            EndAt = appointment.EndAt
        }).ToList();
        return response.GetSuccessResponse(data, Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<List<MedicalRecordResponseDto>>> GetDoctorRecords()
    {
        var response = new ResponseDto<List<MedicalRecordResponseDto>>();
        var userId = CurrentUser.UserId;
        if (string.IsNullOrWhiteSpace(userId))
            return response.GetErrorResponse(Localization.InvalidRequest);

        var records = await UnitOfWork.ClinicalRecordRepository.GetDoctorRecordsAsync(userId);
        return response.GetSuccessResponse(records.Select(ToDto).ToList(), Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<List<MedicalRecordResponseDto>>> GetMyPatientRecords()
    {
        var response = new ResponseDto<List<MedicalRecordResponseDto>>();
        var userId = CurrentUser.UserId;
        if (string.IsNullOrWhiteSpace(userId))
            return response.GetErrorResponse(Localization.InvalidRequest);

        var records = await UnitOfWork.ClinicalRecordRepository.GetPatientRecordsAsync(userId);
        return response.GetSuccessResponse(records.Select(ToDto).ToList(), Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<MedicalRecordResponseDto>> CreateRecord(CreateMedicalRecordRequestDto request)
    {
        var response = new ResponseDto<MedicalRecordResponseDto>();
        var userId = CurrentUser.UserId;
        var prescriptionItems = request.PrescriptionItems
            .Where(item => !string.IsNullOrWhiteSpace(item.MedicationName) ||
                           !string.IsNullOrWhiteSpace(item.Dosage) ||
                           !string.IsNullOrWhiteSpace(item.Frequency) ||
                           !string.IsNullOrWhiteSpace(item.Duration) ||
                           !string.IsNullOrWhiteSpace(item.Instructions))
            .ToList();

        if (string.IsNullOrWhiteSpace(userId) || request.AppointmentId <= 0 ||
            string.IsNullOrWhiteSpace(request.Diagnosis) || prescriptionItems.Count > 20)
            return response.GetErrorResponse(Localization.InvalidData);

        var appointment = await UnitOfWork.ClinicalRecordRepository.GetAppointmentForDoctorAsync(
            request.AppointmentId, userId);
        if (appointment is null)
            return response.GetErrorResponse("The appointment is not eligible for a record or belongs to another doctor.");

        var doctor = await UnitOfWork.ClinicalRecordRepository.GetDoctorByUserIdAsync(userId);
        if (doctor is null)
            return response.GetErrorResponse(Localization.NoDataFound);

        var now = DateTime.UtcNow;
        var record = new MedicalRecord
        {
            AppointmentId = appointment.AppointmentId,
            PatientId = appointment.PatientId,
            DoctorId = doctor.DoctorId,
            Symptoms = Clean(request.Symptoms),
            Diagnosis = request.Diagnosis.Trim(),
            TreatmentNotes = Clean(request.TreatmentNotes),
            CreationTime = now,
            CreatorUserId = userId
        };

        if (prescriptionItems.Count > 0 || !string.IsNullOrWhiteSpace(request.PrescriptionInstructions))
        {
            var prescription = new Prescription
            {
                GeneralInstructions = Clean(request.PrescriptionInstructions),
                CreationTime = now,
                CreatorUserId = userId
            };

            foreach (var item in prescriptionItems)
            {
                if (string.IsNullOrWhiteSpace(item.MedicationName))
                    return response.GetErrorResponse(Localization.InvalidData);

                prescription.Items.Add(new PrescriptionItem
                {
                    MedicationName = item.MedicationName.Trim(),
                    Dosage = Clean(item.Dosage),
                    Frequency = Clean(item.Frequency),
                    Duration = Clean(item.Duration),
                    Instructions = Clean(item.Instructions),
                    CreationTime = now,
                    CreatorUserId = userId
                });
            }

            record.Prescriptions.Add(prescription);
        }

        appointment.AppointmentStatusId = (int)AppointmentStatusEnum.Completed;
        appointment.LastModificationTime = now;
        appointment.LastModifierUserId = userId;
        await UnitOfWork.ClinicalRecordRepository.AddRecordAsync(record);

        try
        {
            if (await UnitOfWork.Commit() <= 0)
                return response.GetErrorResponse(Localization.GeneralError);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Failed to create a medical record for appointment {AppointmentId}.", appointment.AppointmentId);
            return response.GetErrorResponse(Localization.GeneralError);
        }

        await _notifications.NotifyPatientRecordAsync(record.MedicalRecordId);

        return response.GetSuccessResponse(new MedicalRecordResponseDto
        {
            MedicalRecordId = record.MedicalRecordId,
            AppointmentId = record.AppointmentId,
            DoctorName = doctor.EnName,
            PatientName = appointment.Patient.User?.FullName ?? "Patient",
            AppointmentAt = appointment.StartAt,
            Symptoms = record.Symptoms,
            Diagnosis = record.Diagnosis,
            TreatmentNotes = record.TreatmentNotes,
            PrescriptionInstructions = record.Prescriptions.FirstOrDefault()?.GeneralInstructions,
            PrescriptionItems = prescriptionItems
        }, Localization.GeneralSuccess);
    }

    private static MedicalRecordResponseDto ToDto(MedicalRecord record) => new()
    {
        MedicalRecordId = record.MedicalRecordId,
        AppointmentId = record.AppointmentId,
        DoctorName = record.Doctor.EnName,
        PatientName = record.Patient.User?.FullName ?? "Patient",
        AppointmentAt = record.Appointment.StartAt,
        Symptoms = record.Symptoms,
        Diagnosis = record.Diagnosis,
        TreatmentNotes = record.TreatmentNotes,
        PrescriptionInstructions = record.Prescriptions.FirstOrDefault()?.GeneralInstructions,
        PrescriptionItems = record.Prescriptions.SelectMany(prescription => prescription.Items).Select(item => new PrescriptionItemDto
        {
            MedicationName = item.MedicationName,
            Dosage = item.Dosage,
            Frequency = item.Frequency,
            Duration = item.Duration,
            Instructions = item.Instructions
        }).ToList(),
        Attachments = record.UploadedAttachments.Select(item => new MedicalRecordAttachmentDto
        {
            AttachmentId = item.UploadedAttachmentId,
            FileName = item.FileName
        }).ToList()
    };

    private static string? Clean(string? value) => string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}
