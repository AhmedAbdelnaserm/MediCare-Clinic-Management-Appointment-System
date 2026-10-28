using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MediCare.Core.Entity.Entity
{
    public class MedicalRecord
    {
        public int MedicalRecordId { get; set; }

        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string TreatmentNotes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
