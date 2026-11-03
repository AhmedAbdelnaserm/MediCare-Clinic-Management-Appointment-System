using MediCare.Core.Entity.Entity;

namespace MediCare.Core.IRepository.IRepository
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<Patient?> GetByIdWithUserAsync(int patientId);
        Task<IEnumerable<Patient>> GetAllWithUserAsync();
        Task<Patient?> GetByUserIdAsync(string userId);
    }
}
