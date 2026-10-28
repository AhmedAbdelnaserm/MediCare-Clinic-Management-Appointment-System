using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediCare.Core.Entity.Entity
{
    public class Specialization
    {
        public int SpecializationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
