using MediCare.Common.Dto;
using MediCare.Common.Enum;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Shared.Extensions;

public static class ControllerResponseExtensions
{
    public static IActionResult ToHttpResult<T>(
        this ControllerBase controller,
        ResponseDto<T> response)
    {
        return response.Code switch
        {
            ResultStatusEnum.Success => controller.Ok(response),
            ResultStatusEnum.InvalidUserNameOrPassword => controller.Unauthorized(response),
            ResultStatusEnum.Duplicated => controller.Conflict(response),
            _ => controller.BadRequest(response)
        };
    }
}
