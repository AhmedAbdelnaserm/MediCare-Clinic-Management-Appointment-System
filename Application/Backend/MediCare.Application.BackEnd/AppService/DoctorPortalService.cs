using AutoMapper;
using MediCare.Application.BackEnd.Base;
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

public class DoctorPortalService : BaseAppService, IDoctorPortalService
{
    private const long MaxProfileImageSize = 5 * 1024 * 1024;
    private static readonly HashSet<string> ImageExtensions = new(StringComparer.OrdinalIgnoreCase)
    {
        ".jpg", ".jpeg", ".png", ".webp"
    };

    private readonly IProfileImageStorage _profileImageStorage;

    public DoctorPortalService(
        IMapper mapper,
        ILocalizationService localization,
        ILogger<DoctorPortalService> logger,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUser,
        IProfileImageStorage profileImageStorage)
        : base(mapper, localization, logger, unitOfWork, currentUser)
    {
        _profileImageStorage = profileImageStorage;
    }

    public async Task<ResponseDto<DoctorProfileDto>> GetMyProfile()
    {
        var response = new ResponseDto<DoctorProfileDto>();
        var doctor = await GetCurrentDoctor();
        if (doctor == null)
            return response.GetErrorResponse(Localization.DoctorProfileNotFound);

        var specializations = await UnitOfWork.DoctorRepository.GetSpecializations();
        var profile = new DoctorProfileDto
        {
            FullName = doctor.User?.FullName ?? doctor.EnName,
            SpecializationId = doctor.SpecializationId,
            SpecializationName = doctor.Specialization?.EnName ?? string.Empty,
            ProfileImage = doctor.ProfileImage,
            DoctorDegree = doctor.DoctorDegree,
            EnDescription = doctor.EnDescription,
            Specializations = specializations.Select(s => new SpecializationOptionDto
            {
                Value = s.SpecializationId.ToString(),
                Name = s.EnName
            }).ToList()
        };

        return response.GetSuccessResponse(profile, Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<DoctorProfileDto>> UpdateMyProfile(
        UpdateDoctorProfileRequestDto request,
        Stream? imageStream,
        string? imageFileName,
        long imageLength)
    {
        var response = new ResponseDto<DoctorProfileDto>();
        if (request == null)
            return response.GetErrorResponse(Localization.InvalidRequest);

        if (request.SpecializationId <= 0 ||
            !await UnitOfWork.DoctorRepository.SpecializationExists(request.SpecializationId))
            return response.GetErrorResponse(Localization.SpecializationRequired);

        if (string.IsNullOrWhiteSpace(request.EnDescription) || request.EnDescription.Trim().Length > 500)
            return response.GetErrorResponse(Localization.DoctorDescriptionRequired);

        var extension = string.IsNullOrWhiteSpace(imageFileName)
            ? null
            : Path.GetExtension(imageFileName).ToLowerInvariant();

        if (imageStream != null && (imageLength <= 0 || imageLength > MaxProfileImageSize ||
                                    extension == null || !ImageExtensions.Contains(extension)))
            return response.GetErrorResponse(Localization.InvalidProfileImage);

        var doctor = await GetCurrentDoctor();
        if (doctor == null)
            return response.GetErrorResponse(Localization.DoctorProfileNotFound);

        try
        {
            if (imageStream != null && extension != null)
                doctor.ProfileImage = await _profileImageStorage.StoreAsync(imageStream, extension);

            doctor.SpecializationId = request.SpecializationId;
            doctor.DoctorDegree = request.DoctorDegree?.Trim();
            doctor.EnDescription = request.EnDescription.Trim();
            doctor.LastModifierUserId = CurrentUser.UserId;
            doctor.LastModificationTime = DateTime.UtcNow;

            UnitOfWork.DoctorRepository.Update(doctor);
            if (await UnitOfWork.Commit() <= 0)
                return response.GetErrorResponse(Localization.GeneralError);

            return response.GetSuccessResponse(await MapProfile(doctor), Localization.DoctorProfileUpdated);
        }
        catch (Exception exception)
        {
            Logger.LogError(exception, "Failed to update professional profile for user {UserId}.", CurrentUser.UserId);
            return response.GetErrorResponse(Localization.GeneralError);
        }
    }

    public async Task<ResponseDto<List<DoctorClinicSummaryDto>>> GetMyClinics()
    {
        var response = new ResponseDto<List<DoctorClinicSummaryDto>>();
        var doctor = await GetCurrentDoctor();
        if (doctor == null)
            return response.GetErrorResponse(Localization.DoctorProfileNotFound);

        var assignments = await UnitOfWork.ClinicDoctorRepository.GetByDoctorId(doctor.DoctorId, "Clinic,WorkingHours");
        var clinics = assignments.Select(assignment => new DoctorClinicSummaryDto
        {
            ClinicId = assignment.ClinicId,
            ClinicName = assignment.Clinic?.EnName ?? string.Empty,
            Address = assignment.Clinic?.Address,
            PhoneNumber = assignment.Clinic?.PhoneNumber,
            ConsultationDurationMinutes = assignment.ConsultationDurationMinutes,
            ConsultationFee = assignment.ConsultationFee,
            WorkingHours = assignment.WorkingHours
                .Where(hour => hour.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted)
                .OrderBy(hour => hour.DayOfWeek)
                .ThenBy(hour => hour.StartTime)
                .Select(hour => new WorkingHourDto
                {
                    DayOfWeek = hour.DayOfWeek,
                    StartTime = hour.StartTime,
                    EndTime = hour.EndTime
                }).ToList()
        }).ToList();

        return response.GetSuccessResponse(clinics, Localization.DoctorClinicsLoaded);
    }

    private Task<Doctor?> GetCurrentDoctor()
    {
        var userId = CurrentUser.UserId;
        return string.IsNullOrWhiteSpace(userId)
            ? Task.FromResult<Doctor?>(null)
            : UnitOfWork.DoctorRepository.GetDoctorByUserId(userId, "User,Specialization");
    }

    private async Task<DoctorProfileDto> MapProfile(Doctor doctor)
    {
        var specializations = await UnitOfWork.DoctorRepository.GetSpecializations();
        return new DoctorProfileDto
        {
            FullName = doctor.User?.FullName ?? doctor.EnName,
            SpecializationId = doctor.SpecializationId,
            SpecializationName = doctor.Specialization?.EnName ?? string.Empty,
            ProfileImage = doctor.ProfileImage,
            DoctorDegree = doctor.DoctorDegree,
            EnDescription = doctor.EnDescription,
            Specializations = specializations.Select(s => new SpecializationOptionDto
            {
                Value = s.SpecializationId.ToString(),
                Name = s.EnName
            }).ToList()
        };
    }
}
