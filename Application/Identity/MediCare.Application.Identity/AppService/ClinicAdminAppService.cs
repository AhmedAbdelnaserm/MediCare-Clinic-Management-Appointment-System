using MediCare.Application.Identity.Dto.ClinicAdminDto;
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

    public ClinicAdminAppService(UserManager<ApplicationUser> userManager,
        IUnitOfWork unitOfWork, ILogger<ClinicAdminAppService> logger, ICurrentUserService currentUser)
    {
        UserManager = userManager;
        UnitOfWork = unitOfWork;
        Logger = logger;
        CurrentUser = currentUser;
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
            return response.GetErrorResponse("Clinic admin was not found.");

        response.SetSuccessResponse(MapToDto(staff));
        return response;
    }

    public async Task<ResponseDto<EmptyResponseDto>> CreateClinicAdmin(
        CreateClinicAdminRequestDto request)
    {
        var response = new ResponseDto<EmptyResponseDto>();

        var clinic = await UnitOfWork.ClinicRepository
            .FirstOrDefaultAsync(x => x.ClinicId == request.ClinicId);

        if (clinic == null)
            return response.GetErrorResponse("Selected clinic was not found.");

        var existingUser = await UserManager.FindByEmailAsync(request.Email);

        if (existingUser != null)
            return response.GetErrorResponse("Email is already registered.");

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
            return response.GetErrorResponse(
                string.Join(" ", createResult.Errors.Select(x => x.Description)));

        var roleResult = await UserManager.AddToRoleAsync(
            user, nameof(UserRolesEnum.ClinicAdmin));

        if (!roleResult.Succeeded)
        {
            await UserManager.DeleteAsync(user);

            return response.GetErrorResponse(
                string.Join(" ", roleResult.Errors.Select(x => x.Description)));
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

            return response.GetErrorResponse("Could not create clinic admin.");
        }

        return response.GetSuccessResponse("Clinic admin created successfully.");
    }

    public async Task<ResponseDto<EmptyResponseDto>> UpdateClinicAdmin(
        string userId,
        UpdateClinicAdminRequestDto request)
    {
        var response = new ResponseDto<EmptyResponseDto>();

        var staff = await UnitOfWork.ClinicStaffRepository.GetByUserId(userId);

        if (staff == null ||
            !await UserManager.IsInRoleAsync(staff.User, nameof(UserRolesEnum.ClinicAdmin)))
            return response.GetErrorResponse("Clinic admin was not found.");

        var clinic = await UnitOfWork.ClinicRepository
            .FirstOrDefaultAsync(x => x.ClinicId == request.ClinicId);

        if (clinic == null)
            return response.GetErrorResponse("Selected clinic was not found.");

        var normalizedEmail = request.Email.Trim();
        var existingUser = await UserManager.FindByEmailAsync(normalizedEmail);

        if (existingUser != null && existingUser.Id != userId)
            return response.GetErrorResponse("Email is already used by another account.");

        staff.User.FullName = request.FullName.Trim();
        staff.User.PhoneNumber = request.PhoneNumber;
        staff.User.Email = normalizedEmail;
        staff.User.UserName = normalizedEmail;

        // UserManager and this repository share the scoped DbContext. Updating the
        // tracked ClinicStaff before UpdateAsync saves both changes together.
        staff.ClinicId = request.ClinicId;
        staff.LastModificationTime = DateTime.UtcNow;
        staff.LastModifierUserId = CurrentUser.UserId;

        var userResult = await UserManager.UpdateAsync(staff.User);
        if (!userResult.Succeeded)
            return response.GetErrorResponse(
                string.Join(" ", userResult.Errors.Select(x => x.Description)));

        return response.GetSuccessResponse("Clinic admin updated successfully.");
    }

    public async Task<ResponseDto<EmptyResponseDto>> SetClinicAdminStatus(string userId, bool isActive)
    {
        var response = new ResponseDto<EmptyResponseDto>();

        if (!isActive && string.Equals(CurrentUser.UserId, userId, StringComparison.Ordinal))
            return response.GetErrorResponse("You cannot deactivate your own account.");

        var staff = await UnitOfWork.ClinicStaffRepository.GetByUserId(userId);

        if (staff == null ||
            !await UserManager.IsInRoleAsync(
                staff.User, nameof(UserRolesEnum.ClinicAdmin)))
            return response.GetErrorResponse("Clinic admin was not found.");

        staff.User.LockoutEnabled = true;

        staff.User.LockoutEnd = isActive
            ? null
            : DateTimeOffset.UtcNow.AddYears(100);

        staff.LastModificationTime = DateTime.UtcNow;
        staff.LastModifierUserId = CurrentUser.UserId;

        var result = await UserManager.UpdateAsync(staff.User);

        if (!result.Succeeded)
            return response.GetErrorResponse(
                string.Join(", ", result.Errors.Select(x => x.Description)));

        return response.GetSuccessResponse(
            isActive ? "Clinic admin activated successfully."
                     : "Clinic admin deactivated successfully.");
    }

    private static ClinicAdminDto MapToDto(ClinicStaff staff)
    {
        var isActive = !staff.User.LockoutEnabled ||
                       staff.User.LockoutEnd == null ||
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
}
