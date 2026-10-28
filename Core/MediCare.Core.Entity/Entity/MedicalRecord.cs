using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MediCare.Core.Entity.Entity
{
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string TreatmentNotes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
