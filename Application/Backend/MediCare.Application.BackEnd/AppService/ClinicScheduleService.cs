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
using Microsoft.EntityFrameworkCore;

namespace MediCare.Application.BackEnd.AppService;

public sealed class ClinicScheduleService : BaseAppService, IClinicScheduleService
{
    public ClinicScheduleService(
                ILocalizationService localization,
        ILogger<ClinicScheduleService> logger,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUser)
        : base(localization, logger, unitOfWork, currentUser) { }

    public async Task<ResponseDto<List<ClinicDoctorScheduleSummaryDto>>> GetClinicDoctorLinks()
    {
        var links = await UnitOfWork.ClinicScheduleRepository.GetClinicDoctorLinksAsync();
        return new ResponseDto<List<ClinicDoctorScheduleSummaryDto>>().GetSuccessResponse(
            links.Select(link => new ClinicDoctorScheduleSummaryDto
            {
                ClinicDoctorId = link.ClinicDoctorId,
                ClinicId = link.ClinicId,
                ClinicName = link.Clinic.EnName,
                DoctorName = link.Doctor.EnName,
                SpecializationName = link.Doctor.Specialization.EnName,
                ConsultationDurationMinutes = link.ConsultationDurationMinutes,
                WorkingDaysCount = link.WorkingHours.Select(hour => hour.DayOfWeek).Distinct().Count(),
                IsActive = link.IsActive
            }).ToList(),
            Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<ClinicDoctorScheduleDetailsDto>> GetClinicDoctorSchedule(int clinicDoctorId)
    {
        var response = new ResponseDto<ClinicDoctorScheduleDetailsDto>();
        if (clinicDoctorId <= 0)
            return response.GetErrorResponse(Localization.InvalidData);

        var link = await UnitOfWork.ClinicScheduleRepository.GetClinicDoctorAsync(clinicDoctorId);
        if (link is null)
            return response.GetErrorResponse(Localization.NoDataFound);

        return response.GetSuccessResponse(new ClinicDoctorScheduleDetailsDto
        {
            ClinicDoctorId = link.ClinicDoctorId,
            ClinicName = link.Clinic.EnName,
            DoctorName = link.Doctor.EnName,
            ConsultationDurationMinutes = link.ConsultationDurationMinutes,
            WorkingHours = link.WorkingHours.OrderBy(hour => hour.DayOfWeek).ThenBy(hour => hour.StartTime)
                .Select(hour => new WorkingHourDto
                {
                    DayOfWeek = (int)hour.DayOfWeek,
                    StartTime = hour.StartTime,
                    EndTime = hour.EndTime
                }).ToList()
        }, Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<int>> CreateClinicDoctorLink(CreateClinicDoctorScheduleDto request)
    {
        var response = new ResponseDto<int>();
        if (request.ClinicId <= 0 || request.DoctorId <= 0 ||
            request.ConsultationDurationMinutes is < 5 or > 240)
            return response.GetErrorResponse(Localization.InvalidData);

        var repository = UnitOfWork.ClinicScheduleRepository;
        if (!await repository.ClinicExistsAsync(request.ClinicId) ||
            !await repository.DoctorExistsAsync(request.DoctorId))
            return response.GetErrorResponse(Localization.NoDataFound);

        if (await repository.ClinicDoctorLinkExistsAsync(request.ClinicId, request.DoctorId))
            return response.GetErrorResponse("This doctor is already assigned to the clinic.", ResultStatusEnum.Duplicated);

        var userId = CurrentUser.UserId;
        if (string.IsNullOrWhiteSpace(userId))
            return response.GetErrorResponse(Localization.InvalidRequest);

        var link = new ClinicDoctor
        {
            ClinicId = request.ClinicId,
            DoctorId = request.DoctorId,
            ConsultationDurationMinutes = request.ConsultationDurationMinutes,
            IsActive = true,
            CreationTime = DateTime.UtcNow,
            CreatorUserId = userId
        };

        await repository.AddClinicDoctorAsync(link);
        await UnitOfWork.Commit();
        return response.GetSuccessResponse(link.ClinicDoctorId, Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<EmptyResponseDto>> ReplaceWorkingHours(
        int clinicDoctorId,
        ReplaceWorkingHoursDto request)
    {
        var response = new ResponseDto<EmptyResponseDto>();
        if (clinicDoctorId <= 0 || request.WorkingHours.Count == 0)
            return response.GetErrorResponse(Localization.InvalidData);

        if (request.WorkingHours.Any(hour => hour.DayOfWeek is < 0 or > 6 ||
                hour.StartTime >= hour.EndTime))
            return response.GetErrorResponse(Localization.InvalidData);

        if (request.WorkingHours.GroupBy(hour => hour.DayOfWeek).Any(day => day.Count() > 2))
            return response.GetErrorResponse("A day can have up to two working intervals.");

        foreach (var day in request.WorkingHours.GroupBy(hour => hour.DayOfWeek))
        {
            var ranges = day.OrderBy(hour => hour.StartTime).ToList();
            for (var index = 1; index < ranges.Count; index++)
            {
                if (ranges[index].StartTime < ranges[index - 1].EndTime)
                    return response.GetErrorResponse("Working time ranges cannot overlap.");
            }
        }

        var link = await UnitOfWork.ClinicScheduleRepository.GetClinicDoctorAsync(clinicDoctorId);
        if (link is null || !link.IsActive || link.ConsultationDurationMinutes <= 0)
            return response.GetErrorResponse(Localization.NoDataFound);

        var userId = CurrentUser.UserId;
        if (string.IsNullOrWhiteSpace(userId))
            return response.GetErrorResponse(Localization.InvalidRequest);

        var workingHours = request.WorkingHours.Select(hour => new WorkingHour
        {
            DayOfWeek = (DayOfWeek)hour.DayOfWeek,
            StartTime = hour.StartTime,
            EndTime = hour.EndTime
        }).ToList();

        link.LastModifierUserId = userId;
        link.LastModificationTime = DateTime.UtcNow;
        await UnitOfWork.ClinicScheduleRepository.ReplaceWorkingHoursAsync(
            clinicDoctorId, workingHours, userId);
        await UnitOfWork.Commit();

        return response.GetSuccessResponse(Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<GeneratedSlotsDto>> GenerateSlots(
        int clinicDoctorId,
        GenerateSlotsDto request)
    {
        var response = new ResponseDto<GeneratedSlotsDto>();
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        if (clinicDoctorId <= 0 || request.StartDate < today ||
            request.EndDate < request.StartDate || request.EndDate > today.AddDays(59))
            return response.GetErrorResponse(Localization.InvalidData);

        var link = await UnitOfWork.ClinicScheduleRepository.GetClinicDoctorAsync(clinicDoctorId);
        if (link is null || !link.IsActive || link.ConsultationDurationMinutes <= 0)
            return response.GetErrorResponse(Localization.NoDataFound);

        var existingTimes = (await UnitOfWork.ClinicScheduleRepository.GetSlotTimesAsync(
            clinicDoctorId, request.StartDate, request.EndDate)).ToHashSet();
        var exceptions = await UnitOfWork.ClinicScheduleRepository.GetScheduleExceptionsAsync(
            clinicDoctorId, request.StartDate, request.EndDate);
        var exceptionsByDate = exceptions.ToDictionary(item => item.ExceptionDate);
        var now = DateTime.UtcNow;
        var userId = CurrentUser.UserId;
        if (string.IsNullOrWhiteSpace(userId))
            return response.GetErrorResponse(Localization.InvalidRequest);

        var slots = new List<Slot>();
        for (var date = request.StartDate; date <= request.EndDate; date = date.AddDays(1))
        {
            if (exceptionsByDate.TryGetValue(date, out var exception) && exception.IsClosed)
                continue;

            var hoursForDay = exceptionsByDate.TryGetValue(date, out exception)
                ? new[] { (Start: exception.StartTime!.Value, End: exception.EndTime!.Value) }
                : link.WorkingHours.Where(hour => hour.DayOfWeek == date.DayOfWeek)
                    .Select(hour => (Start: hour.StartTime, End: hour.EndTime)).ToArray();
            foreach (var hours in hoursForDay)
            {
                var start = date.ToDateTime(hours.Start, DateTimeKind.Utc);
                var end = date.ToDateTime(hours.End, DateTimeKind.Utc);
                var duration = TimeSpan.FromMinutes(link.ConsultationDurationMinutes);

                for (var slotStart = start; slotStart.Add(duration) <= end; slotStart = slotStart.Add(duration))
                {
                    if (slotStart <= now || existingTimes.Contains(slotStart))
                        continue;

                    existingTimes.Add(slotStart);
                    slots.Add(new Slot
                    {
                        ClinicDoctorId = clinicDoctorId,
                        SlotDateTime = slotStart,
                        IsAvailable = true,
                        CreationTime = now,
                        CreatorUserId = userId
                    });
                }
            }
        }

        if (slots.Count > 0)
        {
            try
            {
                await UnitOfWork.ClinicScheduleRepository.AddSlotsAsync(slots);
            }
            catch (DbUpdateException ex)
            {
                Logger.LogWarning(ex, "Concurrent slot generation conflicted for clinic-doctor {ClinicDoctorId}.", clinicDoctorId);
                return response.GetErrorResponse("Available times changed while generating the schedule. Run generation again.");
            }
        }

        return response.GetSuccessResponse(
            new GeneratedSlotsDto { CreatedCount = slots.Count },
            Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<List<ScheduleExceptionDto>>> GetScheduleExceptions(
        int clinicDoctorId, DateOnly startDate, DateOnly endDate)
    {
        var response = new ResponseDto<List<ScheduleExceptionDto>>();
        if (clinicDoctorId <= 0 || endDate < startDate || endDate.DayNumber - startDate.DayNumber > 365)
            return response.GetErrorResponse(Localization.InvalidData);
        var items = await UnitOfWork.ClinicScheduleRepository.GetScheduleExceptionsAsync(clinicDoctorId, startDate, endDate);
        return response.GetSuccessResponse(items.Select(item => new ScheduleExceptionDto
        {
            ScheduleExceptionId = item.ScheduleExceptionId,
            ClinicDoctorId = item.ClinicDoctorId,
            ExceptionDate = item.ExceptionDate,
            IsClosed = item.IsClosed,
            StartTime = item.StartTime,
            EndTime = item.EndTime,
            Reason = item.Reason
        }).ToList(), Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<EmptyResponseDto>> SaveScheduleException(
        int clinicDoctorId, SaveScheduleExceptionDto request)
    {
        var response = new ResponseDto<EmptyResponseDto>();
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var validHours = request.IsClosed
            ? request.StartTime is null && request.EndTime is null
            : request.StartTime is not null && request.EndTime is not null && request.StartTime < request.EndTime;
        if (clinicDoctorId <= 0 || request.ExceptionDate < today || request.ExceptionDate > today.AddDays(365) ||
            !validHours || request.Reason?.Length > 250)
            return response.GetErrorResponse(Localization.InvalidData);

        var userId = CurrentUser.UserId;
        if (string.IsNullOrWhiteSpace(userId))
            return response.GetErrorResponse(Localization.InvalidRequest);
        var link = await UnitOfWork.ClinicScheduleRepository.GetClinicDoctorAsync(clinicDoctorId);
        if (link is null || !link.IsActive)
            return response.GetErrorResponse(Localization.NoDataFound);

        await UnitOfWork.ClinicScheduleRepository.SaveScheduleExceptionAsync(clinicDoctorId, new ScheduleException
        {
            ExceptionDate = request.ExceptionDate,
            IsClosed = request.IsClosed,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            Reason = string.IsNullOrWhiteSpace(request.Reason) ? null : request.Reason.Trim()
        }, userId);
        return response.GetSuccessResponse(Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<EmptyResponseDto>> DeleteScheduleException(int clinicDoctorId, int exceptionId)
    {
        var response = new ResponseDto<EmptyResponseDto>();
        if (clinicDoctorId <= 0 || exceptionId <= 0)
            return response.GetErrorResponse(Localization.InvalidData);
        await UnitOfWork.ClinicScheduleRepository.DeleteScheduleExceptionAsync(clinicDoctorId, exceptionId);
        return response.GetSuccessResponse(Localization.GeneralSuccess);
    }
}
