using MediCare.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MediCare.Core.Entity.Entity
{
    public class ClinicDoctor
    {
        public int ClinicDoctorId { get; set; }

        public int ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public ClinicStatusEnum Status { get; set; }
    }
}
