
using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Application.Identity.Dto.Authentication;
using MediCare.IApplication.Identity.IAppService;
using MediCare.Presentation.Web.Frontend.Mvc.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Frontend.Mvc.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IAuthService _authService;

    public AccountController(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        IAuthService authService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _authService = authService;
    }

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
    [HttpGet]
    public IActionResult Register()
    {
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToRoleDashboard();

        return View(new RegisterViewModel());
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _authService.UserRegister(new RegisterDto
        {
            FullName = model.FullName.Trim(),
            Email = model.Email.Trim(),
            UserName = model.Email.Trim(),
            PhoneNumber = model.PhoneNumber?.Trim(),
            Password = model.Password
        });

        if (result.Code != ResultStatusEnum.Success || result.Data is null)
        {
            ModelState.AddModelError(string.Empty, result.Message);
            return View(model);
        }

        var user = await _userManager.FindByIdAsync(result.Data.UserId);
        if (user is null)
        {
            ModelState.AddModelError(string.Empty, "Your account was created, but we could not sign you in. Please log in.");
            return View("Login", new LoginViewModel { Email = model.Email });
        }

        await _signInManager.SignInAsync(user, isPersistent: false);
        return RedirectToAction("Index", "Dashboard", new { area = "Patient" });
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await _userManager.FindByEmailAsync(model.Email.Trim());
        var result = user is null
            ? Microsoft.AspNetCore.Identity.SignInResult.Failed
            : await _signInManager.PasswordSignInAsync(
                user,
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
