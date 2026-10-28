using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MediCare.Common.Enum;
namespace MediCare.Core.Entity.Entity
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int ClinicDoctorId { get; set; }
        public virtual ClinicDoctor ClinicDoctor { get; set; }
        public string BookedByUserId { get; set; }
        public virtual ApplicationUser BookedByUser { get; set; }

        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public AppointmentStatusEnum Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
    
}
