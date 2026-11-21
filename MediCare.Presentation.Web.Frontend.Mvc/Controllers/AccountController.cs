
using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Infrastructure.Repository.Context;
using MediCare.Presentation.Web.Frontend.Mvc.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Presentation.Web.Frontend.Mvc.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public AccountController(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        ApplicationDbContext context)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _context = context;
    }

    // =========================
    // Patient Registration
    // =========================

    [AllowAnonymous]
    [HttpGet]
    public IActionResult RegisterPatient()
    {
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToRoleDashboard();

        return View(new RegisterPatientViewModel());
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterPatient(
        RegisterPatientViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await using var transaction =
            await _context.Database.BeginTransactionAsync();

        var user = new ApplicationUser
        {
            FullName = model.FullName.Trim(),
            Email = model.Email.Trim(),
            UserName = model.Email.Trim(),
            PhoneNumber = model.PhoneNumber?.Trim()
        };

        var userResult =
            await _userManager.CreateAsync(user, model.Password);

        if (!userResult.Succeeded)
        {
            await transaction.RollbackAsync();
            AddIdentityErrors(userResult);
            return View(model);
        }

        var roleResult = await _userManager.AddToRoleAsync(
            user,
            UserRolesEnum.Patient.ToString());

        if (!roleResult.Succeeded)
        {
            await transaction.RollbackAsync();

            AddIdentityErrors(roleResult);
            return View(model);
        }

        var patient = new Patient
        {
            UserId = user.Id,
            CreationTime = DateTime.UtcNow,
            LastModificationTime = DateTime.UtcNow
        };

        _context.Patients.Add(patient);

        await _context.SaveChangesAsync();
        await transaction.CommitAsync();

        await _signInManager.SignInAsync(user, isPersistent: false);

        return RedirectToAction(
            "Index",
            "Dashboard",
            new { area = "Patient" });
    }

    // =========================
    // Doctor Registration
    // =========================

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> RegisterDoctor()
    {
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToRoleDashboard();

        var model = new RegisterDoctorViewModel();

        await LoadSpecializationsAsync(model);

        return View(model);
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterDoctor(
        RegisterDoctorViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await LoadSpecializationsAsync(model);
            return View(model);
        }

        var specializationExists =
            await _context.Specializations.AnyAsync(
                s => s.SpecializationId == model.SpecializationId);

        if (!specializationExists)
        {
            ModelState.AddModelError(
                nameof(model.SpecializationId),
                "Please select a valid specialization.");

            await LoadSpecializationsAsync(model);
            return View(model);
        }

        await using var transaction =
            await _context.Database.BeginTransactionAsync();

        var user = new ApplicationUser
        {
            FullName = model.FullName.Trim(),
            Email = model.Email.Trim(),
            UserName = model.Email.Trim(),
            PhoneNumber = model.PhoneNumber?.Trim()
        };

        var userResult =
            await _userManager.CreateAsync(user, model.Password);

        if (!userResult.Succeeded)
        {
            await transaction.RollbackAsync();

            AddIdentityErrors(userResult);
            await LoadSpecializationsAsync(model);

            return View(model);
        }

        var roleResult = await _userManager.AddToRoleAsync(
            user,
            UserRolesEnum.Doctor.ToString());

        if (!roleResult.Succeeded)
        {
            await transaction.RollbackAsync();

            AddIdentityErrors(roleResult);
            await LoadSpecializationsAsync(model);

            return View(model);
        }

        var doctor = new Doctor
        {
            UserId = user.Id,
            SpecializationId = model.SpecializationId,

            EnName = model.FullName.Trim(),
            ArName = string.Empty,

            EnDescription = string.Empty,
            ArDescription = string.Empty,

            DoctorDegree = model.DoctorDegree?.Trim(),
            ConsultationFee = 0,

            CreationTime = DateTime.UtcNow,
            LastModificationTime = DateTime.UtcNow
        };

        _context.Doctors.Add(doctor);

        await _context.SaveChangesAsync();
        await transaction.CommitAsync();

        await _signInManager.SignInAsync(user, isPersistent: false);

        return RedirectToAction(
            "Index",
            "Dashboard",
            new { area = "Doctor" });
    }

    // =========================
    // Login
    // =========================

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToRoleDashboard();

        return View(new LoginViewModel
        {
            ReturnUrl = returnUrl
        });
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _signInManager.PasswordSignInAsync(
            model.Email,
            model.Password,
            model.RememberMe,
            lockoutOnFailure: true);

        if (result.Succeeded)
        {
            if (!string.IsNullOrWhiteSpace(model.ReturnUrl) &&
                Url.IsLocalUrl(model.ReturnUrl))
            {
                return LocalRedirect(model.ReturnUrl);
            }

            return await RedirectToRoleDashboardAsync(model.Email);
        }

        if (result.IsLockedOut)
        {
            ModelState.AddModelError(
                string.Empty,
                "Your account is temporarily locked. Please try again later.");
        }
        else
        {
            ModelState.AddModelError(
                string.Empty,
                "Invalid email or password.");
        }

        return View(model);
    }

    // =========================
    // Logout
    // =========================

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction(nameof(Login));
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }

    // =========================
    // Helpers
    // =========================

    private async Task LoadSpecializationsAsync(
        RegisterDoctorViewModel model)
    {
        model.Specializations = await _context.Specializations
            .AsNoTracking()
            .OrderBy(s => s.EnName)
            .Select(s => new SelectListItem
            {
                Value = s.SpecializationId.ToString(),
                Text = s.EnName
            })
            .ToListAsync();
    }

    private void AddIdentityErrors(
        IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(
                string.Empty,
                error.Description);
        }
    }

    private IActionResult RedirectToRoleDashboard()
    {
        if (User.IsInRole(UserRolesEnum.SuperAdmin.ToString()))
            return RedirectToAction("Index", "Dashboard",
                new { area = "SuperAdmin" });

        if (User.IsInRole(UserRolesEnum.ClinicAdmin.ToString()))
            return RedirectToAction("Index", "Dashboard",
                new { area = "Admin" });

        if (User.IsInRole(UserRolesEnum.Doctor.ToString()))
            return RedirectToAction("Index", "Dashboard",
                new { area = "Doctor" });

        if (User.IsInRole(UserRolesEnum.Patient.ToString()))
            return RedirectToAction("Index", "Dashboard",
                new { area = "Patient" });

        return RedirectToAction(nameof(AccessDenied));
    }

    private async Task<IActionResult> RedirectToRoleDashboardAsync(
        string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(AccessDenied));
        }

        var roles = await _userManager.GetRolesAsync(user);

        if (roles.Contains(UserRolesEnum.SuperAdmin.ToString()))
            return RedirectToAction("Index", "Dashboard",
                new { area = "SuperAdmin" });

        if (roles.Contains(UserRolesEnum.ClinicAdmin.ToString()))
            return RedirectToAction("Index", "Dashboard",
                new { area = "Admin" });

        if (roles.Contains(UserRolesEnum.Doctor.ToString()))
            return RedirectToAction("Index", "Dashboard",
                new { area = "Doctor" });

        if (roles.Contains(UserRolesEnum.Patient.ToString()))
            return RedirectToAction("Index", "Dashboard",
                new { area = "Patient" });

        await _signInManager.SignOutAsync();

        return RedirectToAction(nameof(AccessDenied));
    }
}
