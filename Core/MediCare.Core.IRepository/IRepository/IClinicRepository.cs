using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository.Base;

namespace MediCare.Core.IRepository.IRepository
{
    public interface IClinicRepository : IBaseRepository<Clinic>
    {
        Task<Clinic> GetClinic(int clinicId, string includeProperties = "");
        Task<List<Clinic>> GetClinics(string includeProperties = "");
        Task<List<Clinic>> GetClinicsByAreaId(int areaId, string includeProperties = "");
    }
}
