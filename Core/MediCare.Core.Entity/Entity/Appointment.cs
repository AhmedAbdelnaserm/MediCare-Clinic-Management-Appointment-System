using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MediCare.Core.Entity.Entity
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        [ForeignKey("ClinicDoctor")]
        public int ClinicDoctorId { get; set; }
        public virtual ClinicDoctor ClinicDoctor { get; set; }

        [ForeignKey("BookedByUser")]
        public string BookedByUserId { get; set; }
        public virtual ApplicationUser BookedByUser { get; set; }

        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
    public enum AppointmentStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed
    }
}
