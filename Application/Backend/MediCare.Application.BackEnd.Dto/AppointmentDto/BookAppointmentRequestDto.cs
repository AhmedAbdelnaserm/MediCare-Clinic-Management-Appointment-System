using System.ComponentModel.DataAnnotations;

namespace MediCare.Application.BackEnd.Dto.AppointmentDto;

public sealed class BookAppointmentRequestDto
{
    [Range(1, int.MaxValue)]
    public int SlotId { get; set; }
}
