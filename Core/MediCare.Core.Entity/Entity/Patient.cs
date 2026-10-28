using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MediCare.Common.Enum;

namespace MediCare.Core.Entity.Entity
{
    public class Patient
    {
        public int PatientId { get; set; }

        public string? UserId { get; set; } 
        public virtual ApplicationUser User { get; set; }
        [Required]
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime LastVisit { get; set; }
    }
   
}
