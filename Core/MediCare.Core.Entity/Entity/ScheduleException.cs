using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MediCare.Core.Entity.Entity
{
    public class ScheduleException
    {
        public int ScheduleExceptionId { get; set; }

        public int ClinicDoctorId { get; set; }
        public virtual ClinicDoctor ClinicDoctor { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? StartTime { get; set; } 
        public TimeSpan? EndTime { get; set; } 
        public bool IsUnavailable { get; set; }
    }
}
