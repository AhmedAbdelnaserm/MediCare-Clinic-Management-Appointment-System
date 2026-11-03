using System;
using System.Collections.Generic;
using System.Text;

namespace MediCare.Common.Dto
{
    public class AppointmentResponseDto
    {
        public string PatientName { get; set; } = string.Empty;
        public string PatientEmail { get; set; } = string.Empty;
        public string PatientPhoneNumber { get; set; } = string.Empty;
        public DateTime AppointmentDateTime { get; set; }
    }
}
