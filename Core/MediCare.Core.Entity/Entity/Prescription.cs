using MediCare.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MediCare.Core.Entity.Entity
{
     public class Prescription
    {
        public int PrescriptionId { get; set; }

        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ApprovalStatusEnum Status { get; set; }

        public virtual ICollection<PrescriptionItem> PrescriptionItems { get; set; } = new List<PrescriptionItem>();
    }

}
