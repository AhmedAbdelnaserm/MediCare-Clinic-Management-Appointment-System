using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.Infrastructure.Repository.Base;
using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Infrastructure.Repository.Repository;

public sealed class PatientRepository : BaseRepository<Patient>, IPatientRepository
{
    public PatientRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public Task<Patient?> GetByUserId(string userId) =>
        AppDbContext.Patients.FirstOrDefaultAsync(patient =>
            patient.UserId == userId &&
            patient.DeleteStatusId == (int)DeleteStatusEnum.NotDeleted);
}
