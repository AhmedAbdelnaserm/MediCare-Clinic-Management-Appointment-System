using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MediCare.Core.Entity.Entity
{
    public class PrescriptionItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Prescription")]
        public int PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }

        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public Frequency Frequency { get; set; }
        public string Duration { get; set; }
        public string Instructions { get; set; }
    }
    public enum Frequency
    {
        OnceADay,
        TwiceADay,
        ThriceADay,
        EveryOtherDay,
        Weekly,
        Monthly
    }
}
