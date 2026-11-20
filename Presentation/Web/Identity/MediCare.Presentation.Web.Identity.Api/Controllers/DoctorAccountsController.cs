using MediCare.Application.Identity.Dto.DoctorDto;
using MediCare.Common.Enum;
using MediCare.IApplication.Identity.IAppService;
using MediCare.Presentation.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Identity.Api.Controllers;

[ApiController]
[Route("api/doctor-accounts")]
[Authorize(Roles = nameof(UserRolesEnum.SuperAdmin))]
public sealed class DoctorAccountsController : ControllerBase
{
    private readonly IDoctorAccountService _doctorAccountService;

    public DoctorAccountsController(IDoctorAccountService doctorAccountService) =>
        _doctorAccountService = doctorAccountService;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDoctorAccountRequestDto request) =>
        this.ToHttpResult(await _doctorAccountService.Create(request));
}
