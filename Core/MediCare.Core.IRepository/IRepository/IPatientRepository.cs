using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository.Base;

namespace MediCare.Core.IRepository.IRepository;

public interface IPatientRepository : IBaseRepository<Patient>
{
    Task<Patient?> GetByUserId(string userId);
}
