using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity
{
    public class Slot : BaseEntity
    {
        public int SlotId { get; set; }

        public int ClinicDoctorId { get; set; }
        public ClinicDoctor ClinicDoctor { get; set; } = null!;

        public DateTime SlotDateTime { get; set; }
        public bool IsAvailable { get; set; } = true;

        public ICollection<Appointment> Appointments { get; set; }
        = new List<Appointment>();
    }
}
