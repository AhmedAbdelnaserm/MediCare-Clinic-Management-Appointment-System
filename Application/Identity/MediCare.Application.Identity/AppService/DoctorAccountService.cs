using MediCare.Application.Identity.Dto.DoctorDto;
using MediCare.Common.Dto;
using MediCare.Common.Enum;
using MediCare.Common.Interface;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.Identity.IAppService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace MediCare.Application.Identity.AppService;

public sealed class DoctorAccountService : IDoctorAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUser;
    private readonly ILogger<DoctorAccountService> _logger;

    public DoctorAccountService(
        UserManager<ApplicationUser> userManager,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUser,
        ILogger<DoctorAccountService> logger)
    {
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _currentUser = currentUser;
        _logger = logger;
    }

    public async Task<ResponseDto<DoctorAccountDto>> Create(CreateDoctorAccountRequestDto request)
    {
        var response = new ResponseDto<DoctorAccountDto>();
        var email = request.Email.Trim();
        if (string.IsNullOrWhiteSpace(_currentUser.UserId) ||
            string.IsNullOrWhiteSpace(request.FullName) ||
            string.IsNullOrWhiteSpace(request.EnName) ||
            string.IsNullOrWhiteSpace(request.EnDescription) ||
            request.ConsultationFee < 0)
            return response.GetErrorResponse("Invalid doctor account information.");

        if (!await _unitOfWork.DoctorRepository.SpecializationExists(request.SpecializationId))
            return response.GetErrorResponse("Selected specialization was not found.");

        if (await _userManager.FindByEmailAsync(email) is not null)
            return response.GetErrorResponse("Email is already registered.", ResultStatusEnum.Duplicated);

        var user = new ApplicationUser
        {
            FullName = request.FullName.Trim(),
            Email = email,
            UserName = email,
            PhoneNumber = request.PhoneNumber?.Trim(),
            EmailConfirmed = false
        };

        var created = await _userManager.CreateAsync(user, request.Password);
        if (!created.Succeeded)
            return response.GetErrorResponse(string.Join(" ", created.Errors.Select(error => error.Description)));

        var role = await _userManager.AddToRoleAsync(user, nameof(UserRolesEnum.Doctor));
        if (!role.Succeeded)
        {
            await _userManager.DeleteAsync(user);
            return response.GetErrorResponse(string.Join(" ", role.Errors.Select(error => error.Description)));
        }

        try
        {
            var doctor = new Doctor
            {
                UserId = user.Id,
                SpecializationId = request.SpecializationId,
                ConsultationFee = request.ConsultationFee,
                EnName = request.EnName.Trim(),
                ArName = string.Empty,
                EnDescription = request.EnDescription.Trim(),
                ArDescription = string.Empty,
                DoctorDegree = request.DoctorDegree?.Trim(),
                ProfileImage = request.ProfileImage?.Trim(),
                CreationTime = DateTime.UtcNow,
                CreatorUserId = _currentUser.UserId
            };

            await _unitOfWork.DoctorRepository.CreateAsync(doctor);
            if (await _unitOfWork.Commit() <= 0)
                throw new InvalidOperationException("The doctor profile could not be saved.");

            return response.GetSuccessResponse(new DoctorAccountDto
            {
                UserId = user.Id,
                DoctorId = doctor.DoctorId,
                FullName = user.FullName,
                Email = user.Email ?? email
            }, "Doctor account created successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create doctor profile for {Email}.", email);
            var existingUser = await _userManager.FindByIdAsync(user.Id);
            if (existingUser is not null)
                await _userManager.DeleteAsync(existingUser);
            return response.GetErrorResponse("Could not create doctor account.");
        }
    }
}
