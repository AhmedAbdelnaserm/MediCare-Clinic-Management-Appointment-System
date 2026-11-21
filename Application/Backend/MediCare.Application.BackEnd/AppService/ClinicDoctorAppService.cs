using AutoMapper;
using MediCare.Application.BackEnd.Base;
using MediCare.Application.BackEnd.Dto.ClinicDoctorDto;
using MediCare.Application.BackEnd.Dto.ClinicDto;
using MediCare.Application.BackEnd.Dto.DoctorDto;
using MediCare.Application.BackEnd.Localization;
using MediCare.Common.Dto;
using MediCare.Common.Enum;
using MediCare.Common.Interface;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.Extensions.Logging;

namespace MediCare.Application.BackEnd.AppService;

public class ClinicDoctorAppService : BaseAppService, IClinicDoctorAppService
{
    public ClinicDoctorAppService(IMapper mapper, ILocalizationService localization, ILogger<ClinicDoctorAppService> logger,
        IUnitOfWork unitOfWork, ICurrentUserService currentUser) : base(mapper, localization, logger, unitOfWork, currentUser)
    {
    }

    public async Task<ResponseDto<List<ClinicDoctorDto>>> GetClinicDoctors()
    {
        var response = new ResponseDto<List<ClinicDoctorDto>>();

        var staff = await GetCurrentClinicStaff();

        if (staff == null)
            return response.GetErrorResponse("Clinic admin was not found.");

        var clinicDoctors = await UnitOfWork.ClinicDoctorRepository.GetByClinicId(staff.ClinicId);

        var result = clinicDoctors.Select(MapToDto).ToList();

        return response.GetSuccessResponse(result, Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<List<DoctorResponseDto>>> GetAvailableDoctors()
    {
        var response = new ResponseDto<List<DoctorResponseDto>>();

        var staff = await GetCurrentClinicStaff();

        if (staff == null)
            return response.GetErrorResponse("Clinic admin was not found.");

        var doctors = await UnitOfWork.DoctorRepository.GetDoctors("User,Specialization");

        var clinicDoctors = await UnitOfWork.ClinicDoctorRepository.GetByClinicId(staff.ClinicId);

        var assignedDoctorIds = clinicDoctors.Select(x => x.DoctorId).ToHashSet();

        var availableDoctors = doctors.Where(x => !assignedDoctorIds.Contains(x.DoctorId)).ToList();

        var result = Mapper.Map<List<DoctorResponseDto>>(availableDoctors);

        return response.GetSuccessResponse(result, Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<ClinicDoctorDto>> GetClinicDoctor(
        int clinicDoctorId)
    {
        var response = new ResponseDto<ClinicDoctorDto>();

        if (clinicDoctorId <= default(int))
            return response.GetErrorResponse(Localization.InvalidData);

        var staff = await GetCurrentClinicStaff();

        if (staff == null)
            return response.GetErrorResponse("Clinic admin was not found.");

        var clinicDoctor = await UnitOfWork.ClinicDoctorRepository.GetById(clinicDoctorId);

        if (clinicDoctor == null || clinicDoctor.ClinicId != staff.ClinicId)
            return response.GetErrorResponse(Localization.NoDataFound);

        return response.GetSuccessResponse(MapToDto(clinicDoctor), Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<EmptyResponseDto>> AddDoctorToClinic(ClinicDoctorDto request)
    {
        var response = new ResponseDto<EmptyResponseDto>();

        if (request == null)
            return response.GetErrorResponse(Localization.InvalidRequest);

        if (request.DoctorId <= default(int))
            return response.GetErrorResponse(Localization.InvalidDoctorId);

        if (request.ConsultationDurationMinutes <= default(int))
            return response.GetErrorResponse("Consultation duration must be greater than zero.");

        var validationMessage = ValidateWorkingHours(request.WorkingHours);

        if (validationMessage != null)
            return response.GetErrorResponse(validationMessage);

        var staff = await GetCurrentClinicStaff();

        if (staff == null)
            return response.GetErrorResponse("Clinic admin was not found.");

        var doctor = await UnitOfWork.DoctorRepository.GetDoctorById(request.DoctorId, "User,Specialization");

        if (doctor == null)
            return response.GetErrorResponse(Localization.DoctorNotFound);

        var existing = await UnitOfWork.ClinicDoctorRepository.GetByClinicAndDoctor(staff.ClinicId, request.DoctorId);

        if (existing != null && existing.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted && existing.IsActive)
            return response.GetErrorResponse("This doctor is already assigned to your clinic.");

        await using var transaction = UnitOfWork.ClinicDoctorRepository.BeginTransaction();
        try
        {
            var clinicDoctor = existing ?? new ClinicDoctor
            {
                ClinicId = staff.ClinicId,
                DoctorId = request.DoctorId,
                CreatorUserId = CurrentUser.UserId,
                CreationTime = DateTime.UtcNow
            };

            clinicDoctor.ConsultationDurationMinutes = request.ConsultationDurationMinutes;
            clinicDoctor.IsActive = true;
            clinicDoctor.DeleteStatusId = (int)DeleteStatusEnum.NotDeleted;
            clinicDoctor.LastModifierUserId = CurrentUser.UserId;
            clinicDoctor.LastModificationTime = DateTime.UtcNow;

            if (existing == null)
            {
                await UnitOfWork.ClinicDoctorRepository.CreateAsync(clinicDoctor);
            }
            else
            {
                UnitOfWork.ClinicDoctorRepository.Update(clinicDoctor);
            }

            // Save first to obtain ClinicDoctorId for a new relationship.
            await UnitOfWork.Commit();

            await ReplaceWorkingHours(clinicDoctor, request.WorkingHours);

            await UnitOfWork.Commit();

            await SyncFutureSlots(clinicDoctor);

            await UnitOfWork.Commit();

            await transaction.CommitAsync();

            return response.GetSuccessResponse(Localization.GeneralSuccess);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();

            Logger.LogError(ex, "Failed to assign doctor {DoctorId} to clinic {ClinicId}.", request.DoctorId, staff.ClinicId);

            return response.GetErrorResponse(Localization.GeneralError);
        }
    }

    public async Task<ResponseDto<EmptyResponseDto>> UpdateClinicDoctorSchedule(int clinicDoctorId, ClinicDoctorDto request)
    {
        var response = new ResponseDto<EmptyResponseDto>();

        if (clinicDoctorId <= default(int) || request == null)
            return response.GetErrorResponse(Localization.InvalidRequest);

        if (request.ConsultationDurationMinutes <= default(int))
            return response.GetErrorResponse("Consultation duration must be greater than zero.");

        var validationMessage = ValidateWorkingHours(request.WorkingHours);

        if (validationMessage != null)
            return response.GetErrorResponse(validationMessage);

        var staff = await GetCurrentClinicStaff();

        if (staff == null)
            return response.GetErrorResponse("Clinic admin was not found.");

        var clinicDoctor = await UnitOfWork.ClinicDoctorRepository.GetById(clinicDoctorId);

        if (clinicDoctor == null || clinicDoctor.ClinicId != staff.ClinicId)
            return response.GetErrorResponse(Localization.NoDataFound);


        await using var transaction = UnitOfWork.ClinicDoctorRepository.BeginTransaction();

        try
        {
            clinicDoctor.ConsultationDurationMinutes = request.ConsultationDurationMinutes;
            clinicDoctor.LastModifierUserId = CurrentUser.UserId;
            clinicDoctor.LastModificationTime = DateTime.UtcNow;

            UnitOfWork.ClinicDoctorRepository.Update(clinicDoctor);

            await ReplaceWorkingHours(clinicDoctor, request.WorkingHours);

            await UnitOfWork.Commit();

            await SyncFutureSlots(clinicDoctor);

            await UnitOfWork.Commit();

            await transaction.CommitAsync();

            return response.GetSuccessResponse(Localization.GeneralSuccess);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();

            Logger.LogError(ex, "Failed to update schedule for ClinicDoctor {ClinicDoctorId}.", clinicDoctorId);

            return response.GetErrorResponse(Localization.GeneralError);
        }
    }

    public async Task<ResponseDto<EmptyResponseDto>> RemoveDoctorFromClinic(int clinicDoctorId)
    {
        var response = new ResponseDto<EmptyResponseDto>();

        if (clinicDoctorId <= default(int))
            return response.GetErrorResponse(Localization.InvalidData);

        var staff = await GetCurrentClinicStaff();

        if (staff == null)
            return response.GetErrorResponse("Clinic admin was not found.");

        var clinicDoctor = await UnitOfWork.ClinicDoctorRepository.GetById(clinicDoctorId);

        if (clinicDoctor == null || clinicDoctor.ClinicId != staff.ClinicId)
            return response.GetErrorResponse(Localization.NoDataFound);


        await using var transaction = UnitOfWork.ClinicDoctorRepository.BeginTransaction();

        try
        {
            clinicDoctor.IsActive = false;
            clinicDoctor.DeleteStatusId = (int)DeleteStatusEnum.Deleted;
            clinicDoctor.LastModifierUserId = CurrentUser.UserId;
            clinicDoctor.LastModificationTime = DateTime.UtcNow;

            UnitOfWork.ClinicDoctorRepository.Update(clinicDoctor);

            var workingHours = await UnitOfWork.WorkingHourRepository.GetByClinicDoctorId(clinicDoctorId);

            foreach (var workingHour in workingHours)
            {
                workingHour.DeleteStatusId = (int)DeleteStatusEnum.Deleted;
                workingHour.LastModifierUserId = CurrentUser.UserId;
                workingHour.LastModificationTime = DateTime.UtcNow;
            }

            if (workingHours.Count > 0)
                UnitOfWork.WorkingHourRepository.UpdateList(workingHours);

            var futureSlots = await UnitOfWork.SlotRepository.GetByClinicDoctorId(clinicDoctorId, DateTime.Now);

            foreach (var slot in futureSlots)
            {
                // Preserve every slot that has appointment history.
                if (slot.Appointments.Any())
                    continue;

                slot.IsAvailable = false;
                slot.DeleteStatusId = (int)DeleteStatusEnum.Deleted;
                slot.LastModifierUserId = CurrentUser.UserId;
                slot.LastModificationTime = DateTime.UtcNow;
            }

            if (futureSlots.Any(x => !x.Appointments.Any()))
                UnitOfWork.SlotRepository.UpdateList(futureSlots.Where(x => !x.Appointments.Any()).ToList());

            await UnitOfWork.Commit();

            await transaction.CommitAsync();

            return response.GetSuccessResponse(Localization.GeneralSuccess);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();

            Logger.LogError(ex, "Failed to remove ClinicDoctor {ClinicDoctorId}.", clinicDoctorId);

            return response.GetErrorResponse(Localization.GeneralError);
        }
    }

    private async Task<ClinicStaff?> GetCurrentClinicStaff()
    {
        var userId = CurrentUser.UserId;

        if (string.IsNullOrWhiteSpace(userId))
            return null;

        return await UnitOfWork.ClinicStaffRepository.GetByUserId(userId);
    }

    private async Task ReplaceWorkingHours(ClinicDoctor clinicDoctor,List<WorkingHourDto> requestedHours)
    {
        var currentHours = await UnitOfWork.WorkingHourRepository.GetByClinicDoctorId(clinicDoctor.ClinicDoctorId);

        foreach (var hour in currentHours)
        {
            hour.DeleteStatusId = (int)DeleteStatusEnum.Deleted;
            hour.LastModifierUserId = CurrentUser.UserId;
            hour.LastModificationTime = DateTime.UtcNow;
        }

        if (currentHours.Count > default(int))
            UnitOfWork.WorkingHourRepository.UpdateList(currentHours);

        var newHours = requestedHours.Select(x => new WorkingHour
        {
            ClinicDoctorId = clinicDoctor.ClinicDoctorId,
            DayOfWeek = x.DayOfWeek,
            StartTime = x.StartTime,
            EndTime = x.EndTime,
            DeleteStatusId = (int)DeleteStatusEnum.NotDeleted,
            CreationTime = DateTime.UtcNow,
            CreatorUserId = CurrentUser.UserId
        }).ToList();

        await UnitOfWork.WorkingHourRepository.CreateListAsync(newHours);
    }

    private async Task SyncFutureSlots(ClinicDoctor clinicDoctor)
    {
        var now = DateTime.Now;
        var horizon = now.Date.AddDays(7);

        var workingHours = await UnitOfWork.WorkingHourRepository.GetByClinicDoctorId(clinicDoctor.ClinicDoctorId);

        var requestedSlotTimes = new HashSet<DateTime>();

        for (var date = now.Date; date < horizon; date = date.AddDays(1))
        {
            var dayHours = workingHours.Where(x => x.DayOfWeek == date.DayOfWeek);

            foreach (var workingHour in dayHours)
            {
                var slotStart = date.Add(workingHour.StartTime.ToTimeSpan());

                var workingEnd = date.Add(workingHour.EndTime.ToTimeSpan());

                while (slotStart >= now &&slotStart.AddMinutes(clinicDoctor.ConsultationDurationMinutes) <= workingEnd)
                {
                    requestedSlotTimes.Add(slotStart);

                    slotStart = slotStart.AddMinutes(clinicDoctor.ConsultationDurationMinutes);
                }
            }
        }

        // Load all future slots, including soft-deleted ones.
        var existingSlots = await UnitOfWork.SlotRepository.GetByClinicDoctorId(clinicDoctor.ClinicDoctorId, now);

        foreach (var slot in existingSlots)
        {
            // Never modify slots that have appointments.
            if (slot.Appointments.Any())
            {
                requestedSlotTimes.Remove(slot.SlotDateTime);
                continue;
            }

            if (requestedSlotTimes.Remove(slot.SlotDateTime))
            {
                // Restore a previously soft-deleted matching slot.
                if (slot.DeleteStatusId == (int)DeleteStatusEnum.Deleted)
                {
                    slot.DeleteStatusId =(int)DeleteStatusEnum.NotDeleted;

                    slot.IsAvailable = true;
                    slot.LastModifierUserId = CurrentUser.UserId;
                    slot.LastModificationTime = DateTime.UtcNow;

                    UnitOfWork.SlotRepository.Update(slot);
                }
            }
            else
            {
                // This future slot is no longer part of the schedule.
                slot.DeleteStatusId = (int)DeleteStatusEnum.Deleted;
                slot.IsAvailable = false;
                slot.LastModifierUserId = CurrentUser.UserId;
                slot.LastModificationTime = DateTime.UtcNow;

                UnitOfWork.SlotRepository.Update(slot);
            }
        }

        var newSlots = requestedSlotTimes.Select(slotDateTime => new Slot
        {
            ClinicDoctorId = clinicDoctor.ClinicDoctorId,
            SlotDateTime = slotDateTime,
            IsAvailable = true,
            DeleteStatusId = (int)DeleteStatusEnum.NotDeleted,
            CreationTime = DateTime.UtcNow,
            CreatorUserId = CurrentUser.UserId
        }).ToList();

        if (newSlots.Count > default(int))
            await UnitOfWork.SlotRepository.CreateListAsync(newSlots);
    }

    private static string? ValidateWorkingHours(List<WorkingHourDto>? workingHours)
    {
        if (workingHours == null || workingHours.Count == 0)
            return "At least one working hour is required.";

        foreach (var hour in workingHours)
        {
            if (!Enum.IsDefined(typeof(DayOfWeek), hour.DayOfWeek))
                return "Invalid day of week.";

            if (hour.StartTime >= hour.EndTime)
                return "Working hour start time must be before end time.";
        }

        var groupedHours = workingHours.GroupBy(x => x.DayOfWeek);

        foreach (var dayHours in groupedHours)
        {
            var ordered = dayHours.OrderBy(x => x.StartTime).ToList();

            for (var i = 1; i < ordered.Count; i++)
            {
                if (ordered[i].StartTime < ordered[i - 1].EndTime)
                    return "Working hours cannot overlap on the same day.";
            }
        }

        return null;
    }

    private static ClinicDoctorDto MapToDto(ClinicDoctor entity)
    {
        return new ClinicDoctorDto
        {
            ClinicDoctorId = entity.ClinicDoctorId,
            DoctorId = entity.DoctorId,
            DoctorName = entity.Doctor?.EnName ?? string.Empty,
            DoctorEmail = entity.Doctor?.User?.Email ?? string.Empty,
            DoctorPhone = entity.Doctor?.User?.PhoneNumber ?? string.Empty,
            SpecializationName =entity.Doctor?.Specialization?.EnName ?? string.Empty,
            ConsultationDurationMinutes =entity.ConsultationDurationMinutes,
            IsActive = entity.IsActive,
            WorkingHours = entity.WorkingHours.Where(x =>x.DeleteStatusId ==(int)DeleteStatusEnum.NotDeleted)
                .OrderBy(x => x.DayOfWeek)
                .ThenBy(x => x.StartTime)
                .Select(x => new WorkingHourDto
                {
                    DayOfWeek = x.DayOfWeek,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime
                })
                .ToList()
        };
    }
}