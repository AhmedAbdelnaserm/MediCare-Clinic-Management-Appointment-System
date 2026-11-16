using System;
using System.Collections.Generic;
using System.Text;

namespace MediCare.Application.BackEnd.Dto.Dto.Specialization { 

        public class SpecializationDto
        {
            public int SpecializationId { get; set; }
            public string EnName { get; set; } = string.Empty;
            public string ArName { get; set; } = string.Empty;
            public string? EnDescription { get; set; }
            public string? ArDescription { get; set; }

            public string DisplayName { get; set; } = string.Empty;
            public string? DisplayDescription { get; set; }
        }
    
}
