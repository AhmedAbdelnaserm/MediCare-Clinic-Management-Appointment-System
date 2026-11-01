using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity;

public class Specialization: BaseMultiLanguageEntity
{
    public int SpecializationId { get; set; }

    public ICollection<Doctor> Doctors { get; set; }
        = new List<Doctor>();
}
