using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Infrastructure.Repository.Repository
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Patient?> GetByIdWithUserAsync(int patientId)
        {
            return await _dbSet
                .Include(p => p.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PatientId == patientId);
        }

        public async Task<IEnumerable<Patient>> GetAllWithUserAsync()
        {
            return await _dbSet
                .Include(p => p.User)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Patient?> GetByUserIdAsync(string userId)
        {
            return await _dbSet
                .Include(p => p.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.UserId == userId);
        }
    }
}
