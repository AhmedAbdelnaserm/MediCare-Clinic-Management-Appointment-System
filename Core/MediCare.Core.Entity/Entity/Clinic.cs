using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity;

public class Clinic : BaseMultiLanguageEntity
{
    public int ClinicId { get; set; }
    public string Address { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }

    public ICollection<ClinicDoctor> ClinicDoctors { get; set; }
        = new List<ClinicDoctor>();
}
