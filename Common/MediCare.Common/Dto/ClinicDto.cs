
using System.ComponentModel.DataAnnotations;

namespace MediCare.Common.Dto
{
    public class ClinicDto
    {
        #region Properties
        public int ClinicId { get; set; }
        public string EnName { get; set; } = string.Empty;
        public string ArName { get; set; } = string.Empty;
        public string EnDescription { get; set; } = string.Empty;
        public string ArDescription { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public int AreaId { get; set; }
        #endregion
    }

    public class SaveClinicDto
    {
        #region Properties
        
        public string ClinicId { get; set; }
        public string EnName { get; set; } = string.Empty;

        

        public string EnDescription { get; set; } = string.Empty;
        
        public string Address { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public int AreaId { get; set; }
        #endregion
    }
}
