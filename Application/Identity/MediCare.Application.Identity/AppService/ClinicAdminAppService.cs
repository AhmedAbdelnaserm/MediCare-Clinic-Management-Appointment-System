using MediCare.Application.Identity.Dto.ClinicAdminDto;
using MediCare.Application.Identity.Localization;
using System.ComponentModel.DataAnnotations;
using MediCare.Common.Dto;
using MediCare.Common.Enum;
using MediCare.Common.Interface;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.Identity.IAppService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace MediCare.Application.Identity.AppService;

public class ClinicAdminAppService : IClinicAdminAppService
{
    private readonly UserManager<ApplicationUser> UserManager;
    private readonly IUnitOfWork UnitOfWork;
    private readonly ILogger<ClinicAdminAppService> Logger;
    private readonly ICurrentUserService CurrentUser;
    private readonly ILocalizationService Localization;

    public ClinicAdminAppService(UserManager<ApplicationUser> userManager,
        IUnitOfWork unitOfWork, ILogger<ClinicAdminAppService> logger, ICurrentUserService currentUser,
        ILocalizationService localization)
    {
        UserManager = userManager;
        UnitOfWork = unitOfWork;
        Logger = logger;
        CurrentUser = currentUser;
        Localization = localization;
    }

    public async Task<ResponseDto<List<ClinicAdminDto>>> GetClinicAdmins()
    {
        var response = new ResponseDto<List<ClinicAdminDto>>();

        var staff = await UnitOfWork.ClinicStaffRepository.GetClinicStaffs();
        var result = new List<ClinicAdminDto>();

        foreach (var item in staff)
        {
            if (!await UserManager.IsInRoleAsync(item.User, nameof(UserRolesEnum.ClinicAdmin)))
                continue;

            result.Add(MapToDto(item));
        }

        response.SetSuccessResponse(result);
        return response;
    }

    public async Task<ResponseDto<ClinicAdminDto>> GetClinicAdmin(string userId)
    {
        var response = new ResponseDto<ClinicAdminDto>();

        var staff = await UnitOfWork.ClinicStaffRepository.GetByUserId(userId);

        if (staff == null ||
            !await UserManager.IsInRoleAsync(staff.User, nameof(UserRolesEnum.ClinicAdmin)))
            return response.GetErrorResponse(Localization.NoDataFound);

        response.SetSuccessResponse(MapToDto(staff));
        return response;
    }

    public async Task<ResponseDto<EmptyResponseDto>> CreateClinicAdmin(
        CreateClinicAdminRequestDto request)
    {
        var response = new ResponseDto<EmptyResponseDto>();

        var validationErrors = ValidateRequest(request);
        if (validationErrors.Count > 0)
            return response.GetErrorResponse(Localization.InvalidRequest);

        var clinic = await UnitOfWork.ClinicRepository
            .FirstOrDefaultAsync(x => x.ClinicId == request.ClinicId);

        if (clinic == null)
            return response.GetErrorResponse(Localization.NoDataFound);

        var existingUser = await UserManager.FindByEmailAsync(request.Email);

        if (existingUser != null)
            return response.GetErrorResponse(Localization.EmailOrUserNameAlreadyExist);

        var user = new ApplicationUser
        {
            FullName = request.FullName.Trim(),
            Email = request.Email.Trim(),
            UserName = request.Email.Trim(),
            PhoneNumber = request.PhoneNumber,
            EmailConfirmed = false
        };

        var createResult = await UserManager.CreateAsync(user, request.Password);

        if (!createResult.Succeeded)
            return response.GetErrorResponse(Localization.GeneralError);

        var roleResult = await UserManager.AddToRoleAsync(
            user, nameof(UserRolesEnum.ClinicAdmin));

        if (!roleResult.Succeeded)
        {
            await UserManager.DeleteAsync(user);

            return response.GetErrorResponse(Localization.GeneralError);
        }

        var clinicStaff = new ClinicStaff
        {
            UserId = user.Id,
            ClinicId = request.ClinicId,
            CreationTime = DateTime.UtcNow,
            CreatorUserId = CurrentUser.UserId
        };

        try
        {
            await UnitOfWork.ClinicStaffRepository.CreateAsync(clinicStaff);
            await UnitOfWork.Commit();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Failed to link ClinicAdmin to clinic.");
            await UserManager.DeleteAsync(user);

            return response.GetErrorResponse(Localization.GeneralError);
        }

        return response.GetSuccessResponse(Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<EmptyResponseDto>> UpdateClinicAdmin(
        string userId,
        UpdateClinicAdminRequestDto request)
    {
        var response = new ResponseDto<EmptyResponseDto>();

        var validationErrors = ValidateRequest(request);
        if (validationErrors.Count > 0)
            return response.GetErrorResponse(Localization.InvalidRequest);

        var staff = await UnitOfWork.ClinicStaffRepository.GetByUserId(userId);

        if (staff == null ||
            !await UserManager.IsInRoleAsync(staff.User, nameof(UserRolesEnum.ClinicAdmin)))
            return response.GetErrorResponse(Localization.NoDataFound);

        var clinic = await UnitOfWork.ClinicRepository
            .FirstOrDefaultAsync(x => x.ClinicId == request.ClinicId);

        if (clinic == null)
            return response.GetErrorResponse(Localization.NoDataFound);

        var normalizedEmail = request.Email.Trim();
        var existingUser = await UserManager.FindByEmailAsync(normalizedEmail);

        if (existingUser != null && existingUser.Id != userId)
            return response.GetErrorResponse(Localization.EmailOrUserNameAlreadyExist);

        staff.User.FullName = request.FullName.Trim();
        staff.User.PhoneNumber = request.PhoneNumber;

        var emailResult = await UserManager.SetEmailAsync(staff.User, normalizedEmail);
        if (!emailResult.Succeeded)
            return response.GetErrorResponse(Localization.GeneralError);

        var usernameResult = await UserManager.SetUserNameAsync(staff.User, normalizedEmail);
        if (!usernameResult.Succeeded)
            return response.GetErrorResponse(Localization.GeneralError);

        var userResult = await UserManager.UpdateAsync(staff.User);
        if (!userResult.Succeeded)
            return response.GetErrorResponse(Localization.GeneralError);

        staff.ClinicId = request.ClinicId;
        staff.LastModificationTime = DateTime.UtcNow;
        staff.LastModifierUserId = CurrentUser.UserId;

        UnitOfWork.ClinicStaffRepository.Update(staff);
        await UnitOfWork.Commit();

        return response.GetSuccessResponse(Localization.GeneralSuccess);
    }

    public async Task<ResponseDto<EmptyResponseDto>> SetClinicAdminStatus(string userId, bool isActive)
    {
        var response = new ResponseDto<EmptyResponseDto>();

        var staff = await UnitOfWork.ClinicStaffRepository.GetByUserId(userId);

        if (staff == null ||
            !await UserManager.IsInRoleAsync(
                staff.User, nameof(UserRolesEnum.ClinicAdmin)))
            return response.GetErrorResponse(Localization.NoDataFound);

        staff.User.LockoutEnabled = true;

        staff.User.LockoutEnd = isActive
            ? null
            : DateTimeOffset.UtcNow.AddYears(100);

        var result = await UserManager.UpdateAsync(staff.User);

        if (!result.Succeeded)
            return response.GetErrorResponse(Localization.GeneralError);

        staff.LastModificationTime = DateTime.UtcNow;
        staff.LastModifierUserId = CurrentUser.UserId;

        UnitOfWork.ClinicStaffRepository.Update(staff);
        await UnitOfWork.Commit();

        return response.GetSuccessResponse(Localization.GeneralSuccess);
    }

    private static ClinicAdminDto MapToDto(ClinicStaff staff)
    {
        var isActive = staff.User.LockoutEnd == null ||
                       staff.User.LockoutEnd <= DateTimeOffset.UtcNow;

        return new ClinicAdminDto
        {
            UserId = staff.UserId,
            FullName = staff.User.FullName ?? string.Empty,
            Email = staff.User.Email ?? string.Empty,
            PhoneNumber = staff.User.PhoneNumber,
            ClinicId = staff.ClinicId,
            ClinicName = staff.Clinic.EnName,
            IsActive = isActive
        };
    }
    private List<string> ValidateRequest(object? request)
    {
        if (request == null)
            return [Localization.InvalidRequest];

        var validationResults = new List<ValidationResult>();
        Validator.TryValidateObject(request, new ValidationContext(request), validationResults, validateAllProperties: true);

        return validationResults
            .Select(result => result.ErrorMessage ?? Localization.InvalidRequest)
            .ToList();
    }
}