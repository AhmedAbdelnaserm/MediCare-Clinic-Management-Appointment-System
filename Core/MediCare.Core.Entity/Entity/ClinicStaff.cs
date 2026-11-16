using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity
{
    public class ClinicStaff : BaseEntity
    {
        public int ClinicStaffId { get; set; }

        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = null!;

        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; } = null!;
    }
}