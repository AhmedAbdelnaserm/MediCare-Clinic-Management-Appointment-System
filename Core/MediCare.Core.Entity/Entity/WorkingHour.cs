using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MediCare.Core.Entity.Entity
{
    public class WorkingHour
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ClinicDoctor")]
        public int ClinicDoctorId { get; set; }
        public virtual ClinicDoctor ClinicDoctor { get; set; }
        public DayOfWeekEnum DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
    public enum DayOfWeekEnum
    {
        Sunday=1,
        Monday=2,
        Tuesday=3,
        Wednesday=4,
        Thursday=5,
        Friday=6,
        Saturday=7
    }
}
