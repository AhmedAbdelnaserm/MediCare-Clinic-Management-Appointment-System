using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace MediCare.Application.BackEnd.Dto.Dto.Specialization
{

        public class UpdateSpecializationDto
        {
            [Required]
            public int SpecializationId { get; set; }

            [Required(ErrorMessage = "English name is required")]
            public string EnName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Arabic name is required")]
            public string ArName { get; set; } = string.Empty;

            public string? EnDescription { get; set; }
            public string? ArDescription { get; set; }
        
    }
}
