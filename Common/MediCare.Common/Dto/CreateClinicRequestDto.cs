using System;
using System.Collections.Generic;
using System.Text;

namespace MediCare.Common.Dto
{
    public class CreateClinicRequestDto
    {
        #region Properties
        public string EnName { get; set; } = string.Empty;
        public string EnDescription { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public int AreaId { get; set; }
        #endregion
    }
}
