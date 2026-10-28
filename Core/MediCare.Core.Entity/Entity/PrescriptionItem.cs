using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MediCare.Common.Enum;
namespace MediCare.Core.Entity.Entity
{
    public class PrescriptionItem
    {
        public int PrescriptionItemId { get; set; }

        public int PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }

        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public FrequencyEnum Frequency { get; set; }
        public string Duration { get; set; }
        public string Instructions { get; set; }
    }
    
}
