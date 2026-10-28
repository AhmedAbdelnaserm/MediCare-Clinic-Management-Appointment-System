using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MediCare.Core.Entity.Entity
{
    public class ClinicDoctor
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Clinic")]
        public int ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public ClinicDoctorStatus Status { get; set; }
    }
    public enum ClinicDoctorStatus
    {
        Active,
        Inactive
    }
}
