
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
        [Required]
        public string EnName { get; set; } = string.Empty;

        [Required]
        public string ArName { get; set; } = string.Empty;

        public string EnDescription { get; set; } = string.Empty;
        public string ArDescription { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        [Range(1, int.MaxValue)]
        public int AreaId { get; set; }
        #endregion
    }
}
