using System.ComponentModel.DataAnnotations;

namespace MediCare.Application.BackEnd.Dto.AppointmentDto;

public sealed class CancelAppointmentRequestDto
{
    [StringLength(500)]
    public string? Reason { get; set; }
}

public sealed class RescheduleAppointmentRequestDto
{
    [Range(1, int.MaxValue)]
    public int SlotId { get; set; }
}
