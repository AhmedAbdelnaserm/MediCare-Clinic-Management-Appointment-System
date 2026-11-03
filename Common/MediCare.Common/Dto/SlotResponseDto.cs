using System;
using System.Collections.Generic;
using System.Text;

namespace MediCare.Common.Dto
{
    public class SlotResponseDto
    {
        public DateTime SlotDateTime { get; set; }
        public bool IsAvailable { get; set; } = true;
        public List<AppointmentResponseDto> Appointments { get; set; } = new List<AppointmentResponseDto>();
    }
}
