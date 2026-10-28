using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MediCare.Common.Enum;

namespace MediCare.Core.Entity.Entity
{
    public class Clinic
    {
        public int ClinicId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ClinicStatusEnum Status { get; set; }
    }
}
